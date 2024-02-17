
namespace Knv.DAQ.IO
{
    using System;
    using System.Globalization;

    public enum WaveRunMode
    {
        RUN_SINGLE,
        RUN_CONTINUOUS
    };

    public enum WaveForm
    {
        WAVE_DC,
        WAVE_HALF_SINE,
        WAVE_SINE,
        WAVE_SINE_50Hz,
        WAVE_SINE_1kHz,
        WAVE_SQURE,
        WAVE_CUSTOM,
    };

    public class AnalogOutput
    {

        const double STM32_VREF = 3.3;
        const int STM32_ADC_MAX = 4096;
        const double STM32_LSB = STM32_VREF / STM32_ADC_MAX;
        const double AO_MUL = 3.0303;
        const int APB_CLOCK = 72000000;

        private readonly int _channel;
        private Func<string, string> _writeRead;

        public WaveRunMode RunMode { get; set; }

        int _adcAmplitude;
        public double Amplitude 
        { 
            get
            {
                double value = STM32_LSB * _adcAmplitude * AO_MUL;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
            set
            {
                double divVolts = value / AO_MUL;
                int adc = (int)(divVolts / STM32_LSB);
                if (adc > STM32_ADC_MAX - 1)
                    adc = STM32_ADC_MAX - 1;
                _adcAmplitude = adc;
            }
        }

        int _adcOffset;
        public double Offset 
        {
            get
            {
                double value = STM32_LSB * _adcOffset * AO_MUL;
                double rounded = Math.Round(value, 2);
                return rounded;
            }
            set
            {
                double divVolts = value / AO_MUL;
                int adc = (int)(divVolts / STM32_LSB);
                if (adc > STM32_ADC_MAX - 1)
                    adc = STM32_ADC_MAX - 1;
                _adcOffset = adc;
            }
        }
    
        public int DutyCycle { get; set; }
        public int SamplesCount { get; set; }
        public int Prescaler { get; set; }

        public AnalogOutput(int ch, Func<string, string> writeRead)
        {
            _channel = ch;
            this._writeRead = writeRead;
        }

        public void SelectWave(WaveForm wave)
        {
            var response = _writeRead($"AO{_channel}:WAV:TYP {(int)wave:X2}");
        }

        public WaveForm SelectedWave()
        {
            int wave = int.Parse(_writeRead($"AO{_channel}:WAV:TYP?"), NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));

            return (WaveForm)wave;
        }

        public void WriteConfig()
        {
            if (_adcOffset > 1)
                _adcOffset -= 1;

            string cmd = $"AO{_channel}:WAV:CFG {(int)RunMode:X2} {_adcAmplitude:X4} {_adcOffset:X4} {DutyCycle:X2} {SamplesCount:X4} {Prescaler:X4}";
            var response = _writeRead(cmd);
        }

        public int ApbClock
        {
            get { return APB_CLOCK; }
        }

        public void ReadConfig()
        {
            string cmd = $"AO{_channel}:WAV:CFG?";
            var response = _writeRead(cmd);
            var args = response.Split(' ');

            RunMode = (WaveRunMode)int.Parse(args[0], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            _adcAmplitude = int.Parse(args[1], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            _adcOffset = int.Parse(args[2], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            DutyCycle = int.Parse(args[3], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            SamplesCount = int.Parse(args[4], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
            Prescaler = int.Parse(args[5], NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US"));
        }


        public static double CalculatePeriodTime(int prescaler, int samples)
        {
            int arr = 360;
            double tick = APB_CLOCK / (prescaler + 1) / arr;
            double signalPeriodTime = 1 / tick * samples;
            return signalPeriodTime;
        }

        public double PeriodTime 
        {
            get 
            {
                return CalculatePeriodTime(Prescaler, SamplesCount);
            }        
        }

        public void Start()
        {
            WriteConfig();
            string cmd = $"AO{_channel}:WAV:START";
            _writeRead(cmd);
        }

        public void Stop()
        {
            string cmd = $"AO{_channel}:WAV:STOP";
            _writeRead(cmd);
        }
    }
}
