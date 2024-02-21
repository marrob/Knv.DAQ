
namespace Knv.DAQ.IO
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO.Ports;
    using System.Linq;




    internal class AnalogInput
    {

        const double STM32_VREF = 3.3;
        const int    STM32_ADC_MAX = 4096;
        const double STM32_LSB = STM32_VREF / STM32_ADC_MAX;
        const double AI_VOLTAGE_DIV = 3.06;
        const int    HCLK_HZ = 72000000;
        const int    AI_CHANNELS_COUNT = 4;
        const double AI_CONV_CYCLE = 55.5 + 12.5;


        class ChannelsCurrentValue
        {
            public double AI1 { get; private set; }
            public double AI2 { get; private set; }
            public double AI3 { get; private set; }
            public double AI4 { get; private set; }
        }

        class ReadConfiguration
        {
            public int SamplesPerChannel { get; private set; }
            public int BufferSize { get; private set; }
            public int AdcDivider { get; private set; }
            public int BlockSize { get; private set; }

            public ReadConfiguration(Func<string, string> io)
            {
                string cmd = $"AI:CFG?";
                var response = io(cmd);
                var args = response.Split(' ');

                SamplesPerChannel = int.Parse(args[0], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                BufferSize = int.Parse(args[1], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                AdcDivider = int.Parse(args[2], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
                BlockSize = int.Parse(args[3], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            }
        }

        public enum AdcDivider 
        {
            DIV_2 = 2,
            DIV_4 = 4,
            DIV_6 = 6,
            DIV_8 = 8,
        }


        public enum TriggerSource
        { 
            SOFTWARE
        }

        readonly private Func<string, string> _io;


        public AnalogInput(Func<string, string>io)
        {
            _io = io;
        }


        public static double AcquisitionTimeMs(int samplesPerChannel, AdcDivider adcDivider) 
        {

            var f_adc_hz = HCLK_HZ / (int)adcDivider;
            var t_conv_hz = f_adc_hz / AI_CONV_CYCLE;
            var samples = AI_CHANNELS_COUNT * samplesPerChannel;
            var acq_time = samples / t_conv_hz;

            return Math.Round((acq_time * 1000), 4);
        }

        public static double SamplePerSec(AdcDivider adcDivider)
        {
            var f_adc_hz = HCLK_HZ / (int)adcDivider;
            var t_conv_hz = f_adc_hz / AI_CONV_CYCLE;
            return Math.Round(t_conv_hz,0);
        }

        public void SetConfiguration(int samplesPerChannel, AdcDivider adcDivider, TriggerSource trig)
        {
            var response = _io($"AI:CFG {samplesPerChannel:X4} {(int)adcDivider:X2}");
            if (response != "OK")
                throw new ApplicationException(response);
        }

        public void SoftwareTrigger()
        {
            var response = _io("AI:TRIG");
            if (response != "OK")
                throw new ApplicationException(response);
        }

        internal void SelectChannel(int channel)
        {
            var response = _io($"AI:SEL {channel:X2}");
            if (response != "OK")
                throw new ApplicationException(response);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel">AI1 -> 0, AI2 = -> 1.. </param>
        /// <returns></returns>
        public double[] SamplesDownload(int channel)
        {
            var cfg = new ReadConfiguration(_io);
            SelectChannel(channel);

            var buffer = BufferDownload(_io, cfg.BufferSize, cfg.BlockSize);

            UInt16[] values = new UInt16[cfg.SamplesPerChannel];
            for (int i = 0; i < cfg.SamplesPerChannel; i++)
                values[i] = BitConverter.ToUInt16(buffer, i * 2);

            
            double[] volts = new double[cfg.SamplesPerChannel];

            for (int i = 0; i < values.Length; i++)
            {
                var temp_volt = STM32_LSB * values[i] * AI_VOLTAGE_DIV;
                volts[i] = Math.Round(temp_volt, 2);
            }

            return volts;
        }

        internal Byte[] BufferDownload(Func<string, string> io, int bufferSize, int blockSize)
        {
            byte[] buffer = new byte[bufferSize];
            int blocks = bufferSize / blockSize;
            int single_bytes = bufferSize % blockSize;

            int blockAddress = 0;
            int bufferOffset = 0;
            for (int i = 0; i < blocks; i++)
            {
                var data = BufferRead(io, blockAddress, blockSize);
                Array.Copy(data, 0, buffer, bufferOffset, blockSize);
                blockAddress += blockSize;
                bufferOffset += blockSize;
            }

            if (single_bytes > 0)
            {
                var singles = BufferRead(io, blockAddress, single_bytes);
                Array.Copy(singles, 0, buffer, bufferOffset, single_bytes);
            }
            return buffer;
        }

        internal Byte[] BufferRead(Func<string, string> io, int address, int size)
        {
            /*
             * AI:RD <Address of Block> <Size of Block> 
             * <Address of Block> <Size of Block> <Data> <crc>
             */

            var response = io($"AI:RD {address:X8} {size:X4}");

            if (response.Contains('!'))
            {
                throw new ApplicationException(response);
            }
            var array = response.Split(' '); //addr size data crc
            if (array.Length != 4)
                throw new ApplicationException("Read Error: arugments length...");

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
