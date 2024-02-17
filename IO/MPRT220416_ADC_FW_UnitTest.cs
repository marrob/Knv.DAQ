
namespace Knv.DAQ.IO
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.IO.Ports;
    using System.Linq;
    using System.Text;

    [TestFixture]
    internal class MPRT220416_ADC_FW_UnitTest
    {
        const string COM_PORT = "COM13";
        /*
         * 
         * AI:SAMP? 000F
         * FFFF
         * 
         * Samples(2dbyte)  Method                  BaudRate    Download Time
         * 4096             PollSampleBySample      115200      11417 ms
         * 4096             PollSampleBySample      230400      10210 ms
         * 4096             PollSampleBySample      460800       5203 ms
         * 4096             PollSampleBySample      921600       5325 ms
         * 1024             PollSampleBySample      460800       1424 ms
         * 1024             Poll - 256 byte Block   460800        354 ms
         * 
         */

        [Test]
        public void AdcResultDownload_PollSampleBySample()
        {

            var sp = new SerialPort(COM_PORT, 460800, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.NewLine = "\r";
            sp.DtrEnable = true;
            sp.ReadTimeout = 1000;

            var idn = Identification(sp);
            Assert.AreEqual("MPRT220416-ADC", idn);
            AdcSoftwareTrigger(sp);

            var resp = "";

            const int SAMPLE_COUNT = 1024;
            var samples = new List<int>();
            long timestamp = DateTime.Now.Ticks;
            for (int i = 0; i < SAMPLE_COUNT; i++)
            {
                sp.WriteLine($"AI:SMP? {i:X4}");
                resp = sp.ReadLine();
                samples.Add(int.Parse(resp, NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US")));
            }

            Console.WriteLine($"ADC Data Download Time: {(DateTime.Now.Ticks - timestamp) / 10000} ms");

            var lines = new List<string>();
            samples.ForEach(x => lines.Add(x.ToString()));
            var dt = DateTime.Now;
            var fileName = $"MPRT220416_ADC_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            using (var file = new StreamWriter($"{TestContext.CurrentContext.TestDirectory}\\{fileName}", true, Encoding.ASCII))
                lines.ForEach(file.WriteLine);

            sp.Close();
        }

        [Test]
        public void AdcResultDownload_Block()
        {
            /*
             * MEMR <Address of Block> <Size of Block> 
             * <Address of Block> <Size of Block> <Data> <crc>
             */
            var sp = new SerialPort(COM_PORT, 460800, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.NewLine = "\r";
            sp.DtrEnable = true;
            sp.ReadTimeout = 1000;

            var idn = Identification(sp);
            Assert.AreEqual("MPRT220416-ADC", idn);

            long timestamp = DateTime.Now.Ticks;
            int adcSampleBufferSize = GetBufferSize(sp);
            byte[] buffer = new byte[adcSampleBufferSize];
            int block_size = GetMaxBlockSize(sp);
            int blocks = adcSampleBufferSize / block_size;
            int single_bytes = adcSampleBufferSize % block_size;

            AdcSoftwareTrigger(sp);

            int block_address = 0;
            int buffer_offset = 0;
            for (int i = 0; i < blocks; i++)
            {
                var data = MemoryRead(sp, block_address, block_size);
                Array.Copy(data, 0, buffer, buffer_offset, block_size);
                block_address += block_size;
                buffer_offset += block_size;
            }

            var singles = MemoryRead(sp, block_address, single_bytes);
            Array.Copy(singles, 0, buffer, buffer_offset, single_bytes);

            Console.WriteLine($"ADC Data Download Time: {(DateTime.Now.Ticks - timestamp) / 10000} ms");

            int samplesCount = buffer.Length / 2;

            UInt16[] samplesBuffer = new UInt16[samplesCount];
            for (int i = 0; i < samplesCount; i++)
                samplesBuffer[i] = BitConverter.ToUInt16(buffer, i * 2);

            var lines = new List<string>();
            samplesBuffer.ToList().ForEach(x => lines.Add(x.ToString()));
            var dt = DateTime.Now;
            var fileName = $"MPRT220416_ADC_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            using (var file = new StreamWriter($"{TestContext.CurrentContext.TestDirectory}\\{fileName}", true, Encoding.ASCII))
                lines.ForEach(file.WriteLine);

            sp.Close();
        }


        public string Identification(SerialPort sp)
        {
            sp.WriteLine("*IDN?");
            var response = sp.ReadLine();
            return response;
        }

        public int GetMaxBlockSize(SerialPort sp)
        {
            sp.WriteLine("AI:BSIZE?");
            var response = sp.ReadLine();
            int.TryParse(response, NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out int size);
            return size;
        }


        public int GetBufferSize(SerialPort sp)
        {
            sp.WriteLine("AI:SIZE?");
            var response = sp.ReadLine();
            int.TryParse(response, NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out int size);
            return size;
        }


        public void AdcSoftwareTrigger(SerialPort sp)
        {
            sp.WriteLine("AI:TRIG");
            var response = sp.ReadLine();
            if (response != "OK")
                throw new ApplicationException(response);
        }

        public void SelectChannel(SerialPort sp, int channel)
        {
            sp.WriteLine($"AI:SEL {channel:X2}");
            var response = sp.ReadLine();
            if (response != "OK")
                throw new ApplicationException(response);
        }


        public Byte[] MemoryRead(SerialPort sp, int address, int size)
        {
            /*
             * MEMR <Address of Block> <Size of Block> 
             *  <Address of Block> <Size of Block> <Data> <crc>
             */

            sp.WriteLine($"AI:RD {address:X8} {size:X4}");
            var response = sp.ReadLine();

            if (response.Contains('!'))
            {
                throw new ApplicationException(response);
            }
            var array = response.Split(' '); //addr size data crc
            if (array.Length != 4)
                throw new ApplicationException("Flash Read Error: Expected FR ADDRESS SIZE CRC");

            int.TryParse(array[0], NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out int rx_addr);
            UInt16.TryParse(array[1], NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out UInt16 rx_bsize);
            Byte[] rx_data = Tools.StringToByteArray(array[2]);
            UInt16.TryParse(array[3], NumberStyles.HexNumber, CultureInfo.GetCultureInfo("en-US"), out UInt16 rx_crc);

            if (rx_data.Length != rx_bsize)
                new ApplicationException("Size Error:");
            if (rx_addr != address)
                new ApplicationException("Address Error");
            UInt16 calc_crc = Tools.CalcCrc16Ansi(0, rx_data);
            if (calc_crc != rx_crc)
                new ApplicationException("CRC Error");

            return rx_data;
        }


    }
}