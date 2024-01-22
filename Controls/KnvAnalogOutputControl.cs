
namespace Knv.DAQ.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using IO;

    public partial class KnvAnalogOutputControl : UserControl
    {

        Dictionary<string, WaveRunMode> RunList = new Dictionary<string, WaveRunMode>() 
        {
            { "Single", WaveRunMode.RUN_SINGLE },
            { "Continuous", WaveRunMode.RUN_CONTINUOUS },
        };


        Dictionary<string, WaveForm> WaveList = new Dictionary<string, WaveForm>()
        {
            { "DC", WaveForm.WAVE_DC },
            { "Half Sine", WaveForm.WAVE_HALF_SINE },
            { "Sine", WaveForm.WAVE_SINE },
            { "Sine 50Hz", WaveForm.WAVE_SINE_50Hz },
            { "Sine 1kHz", WaveForm.WAVE_SINE_1kHz },
            { "Squre", WaveForm.WAVE_SQURE },
            { "Custom", WaveForm.WAVE_CUSTOM },
        };

        public event EventHandler<double>ValueChanged;
        public event EventHandler<WaveForm> WaveChanged;
        public event EventHandler Start;
        public event EventHandler Stop;

        [Category("KNV")]
        public string Title
        {
            get { return textBoxTitle.Text; }
            set { textBoxTitle.Text = value; }
        }

        double _multi = double.NaN;
        [Category("KNV")]
        public double Multiplier
        {
            get { return _multi; }
            set
            {
                if (_multi != value)
                {
                    _multi = value;
                    textBoxMulti.Text = value.ToString();
                    MultiplierOrOffsetChanged();
                }
            }
        }

        double _offset = double.NaN;
        [Category("KNV")]
        public double Offset
        {
            get { return _offset; }
            set
            {
                if (value != _offset)
                {
                    _offset = value;
                    textBoxOffset.Text = value.ToString();
                    MultiplierOrOffsetChanged();
                }
            }
        }

        [Category("KNV")]
        public string Unit
        {
            get { return textBoxUnit.Text; }
            set { textBoxUnit.Text = value; }
        }


        [Category("KNV")]
        public double Value 
        {
            get
            {
                return trackBar1.Value / 10;
            }
            set
            {
                trackBar1.Value = (int)(value * 10);
                double ao = trackBar1.Value / 10.0;
                labelCustomValue.Text = $"{ao * Multiplier + Offset}{Unit}";
                textBoxRaw.Text = $"{ao:N2}V";
            }
        }

        bool _init = false;

        [Category("KNV")]
        public WaveForm Wave
        {
            get
            {
                int i = comboBoxWave.SelectedIndex;
                return WaveList.Values.ToList()[i];
            }
            set
            {

                comboBoxWave.SelectedIndex = WaveList.Values.ToList().IndexOf(value);
                _init = true;
            }
        }

        [Category("KNV")]
        public WaveRunMode RunMode
        {
            get
            {
                int i = comboBoxRunMode.SelectedIndex;
                return RunList.Values.ToList()[i];
            }
            set
            {
                comboBoxRunMode.SelectedIndex = RunList.Values.ToList().IndexOf(value);
            }
        }


        [Category("KNV")]
        public double WaveAmplitude 
        {
            get { return double.Parse(textBoxAmpl.Text); }
            set { textBoxAmpl.Text = value.ToString(); }
        }

        [Category("KNV")]
        public double WaveOffset
        {
            get { return double.Parse(textBoxWaveOffset.Text); }
            set { textBoxWaveOffset.Text = value.ToString(); }
        }

        [Category("KNV")]
        public int WaveDutyCycle
        {
            get { return int.Parse(textBoxDutyCycle.Text); }
            set { textBoxDutyCycle.Text = value.ToString(); }
        }


        [Category("KNV")]
        public int SamplesCount
        {
            get { return int.Parse(textBoxSamplesCount.Text); }
            set { textBoxSamplesCount.Text = value.ToString(); }
        }

        [Category("KNV")]
        public int Divider
        {
            get { return int.Parse(textBoxDivider.Text); }
            set { textBoxDivider.Text = value.ToString(); }
        }



        void MultiplierOrOffsetChanged()
        {
            double ao = trackBar1.Value / 10.0;
            labelCustomValue.Text = $"{ao * Multiplier + Offset}{Unit}";
            textBoxRaw.Text = $"{ao:N2}V";
        }

        public KnvAnalogOutputControl()
        {
            InitializeComponent();

            foreach (var mode in RunList) 
                comboBoxRunMode.Items.Add(mode);

            comboBoxRunMode.DisplayMember = "Key";
            comboBoxRunMode.SelectedValue = "Value";

            foreach ( var wave in WaveList) 
                comboBoxWave.Items.Add(wave);

            comboBoxWave.DisplayMember = "Key";
            comboBoxWave.SelectedValue = "Value";

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double ao = trackBar1.Value / 10.0;
            labelCustomValue.Text = $"{ao * Multiplier + Offset}{Unit}";
            textBoxRaw.Text = $"{ao:N2}V";
            ValueChanged?.Invoke(this, ao);
        }

        private void textBoxMulti_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMulti.Text, out double value))
            {
                textBoxMulti.BackColor = Color.White;
                Multiplier = value;
            }
            else
            {
                textBoxMulti.BackColor = Color.Red;
            }
        }

        private void textBoxOffset_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxOffset.Text, out double value))
            {
                textBoxOffset.BackColor = Color.White;
                Offset = value;
            }
            else
            {
                textBoxOffset.BackColor = Color.Red;
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            Stop?.Invoke(this, EventArgs.Empty);
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            Start?.Invoke(this, EventArgs.Empty);
        }

        private void comboBoxWave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_init)
                WaveChanged?.Invoke(this, Wave);
        }
    }
}
