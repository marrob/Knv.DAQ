
namespace Knv.DAQ.IO
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.IO.Ports;
    using System.Linq;
    using System.Runtime.Remoting.Channels;
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
            var sp = new SerialPort(COM_PORT, 460800, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.NewLine = "\r";
            sp.DtrEnable = true;
            sp.ReadTimeout = 1000;

            var idn = Identification(sp);
            Assert.AreEqual("MPRT220416-ADC", idn);
            long timestamp = DateTime.Now.Ticks;



            AdcSoftwareTrigger(sp);

            SetConfiguration(sp, customSamplesCount: 1024, adcDivider: 4);

            var cfg = new AnalogInputGetConfiguration(sp);
            UInt16[] valuesBuffer = BufferDownload(sp, cfg.BufferSize, cfg.BlockSize);

            Console.WriteLine($"ADC Data Download Time: {(DateTime.Now.Ticks - timestamp) / 10000} ms");


            var lines = new List<string>();
            valuesBuffer.ToList().ForEach(x => lines.Add(x.ToString()));
            var dt = DateTime.Now;
            var fileName = $"MPRT220416_ADC_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            using (var file = new StreamWriter($"{TestContext.CurrentContext.TestDirectory}\\{fileName}", true, Encoding.ASCII))
                lines.ForEach(file.WriteLine);

            sp.Close();
        }

        class AnalogInputGetConfiguration
        {
            public int CustomSamplesCount { get; private set; }
            public int BufferSize { get; private set; }
            public int AdcDivider { get; private set; }
            public int BlockSize { get; private set; }

            public AnalogInputGetConfiguration(SerialPort sp)
            {
                string cmd = $"AI:CFG?";
                sp.WriteLine(cmd);
                var response = sp.ReadLine();
                var args = response.Split(' ');

                CustomSamplesCount = int.Parse(args[0], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                BufferSize = int.Parse(args[1], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                AdcDivider = int.Parse(args[2], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                BlockSize = int.Parse(args[3], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            }
        }


        public void SetConfiguration(SerialPort sp, int customSamplesCount, int adcDivider)
        {
            sp.WriteLine($"AI:CFG {customSamplesCount:X4} {adcDivider:X2}");
            var response = sp.ReadLine();
            if (response != "OK")
                throw new ApplicationException(response);
        }
     


        public string Identification(SerialPort sp)
        {
            sp.WriteLine("*IDN?");
            var response = sp.ReadLine();
            return response;
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



        public UInt16[] BufferDownload(SerialPort sp, int bufferSize, int blockSize)
        {
            byte[] buffer = new byte[bufferSize];
            int blocks = bufferSize / blockSize;
            int single_bytes = bufferSize % blockSize;

            int blockAddress = 0;
            int bufferOffset = 0;
            for (int i = 0; i < blocks; i++)
            {
                var data = BufferRead(sp, blockAddress, blockSize);
                Array.Copy(data, 0, buffer, bufferOffset, blockSize);
                blockAddress += blockSize;
                bufferOffset += blockSize;
            }

            if (single_bytes > 0)
            {
                var singles = BufferRead(sp, blockAddress, single_bytes);
                Array.Copy(singles, 0, buffer, bufferOffset, single_bytes);
            }


            int samplesCount = buffer.Length / 2;

            UInt16[] valuesBuffer = new UInt16[samplesCount];
            for (int i = 0; i < samplesCount; i++)
                valuesBuffer[i] = BitConverter.ToUInt16(buffer, i * 2);

            return valuesBuffer;
        }




        public Byte[] BufferRead(SerialPort sp, int address, int size)
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