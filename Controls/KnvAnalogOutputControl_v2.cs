
namespace Knv.DAQ.Controls
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using IO;

    public partial class KnvAnalogOutputControl_v2 : UserControl
    {

        readonly Dictionary<string, WaveRunMode> RunList = new Dictionary<string, WaveRunMode>() 
        {
            { "Single", WaveRunMode.RUN_SINGLE },
            { "Continuous", WaveRunMode.RUN_CONTINUOUS },
        };

        readonly Dictionary<string, WaveForm> WaveList = new Dictionary<string, WaveForm>()
        {
            { "DC", WaveForm.WAVE_DC },
            { "Half Sine", WaveForm.WAVE_HALF_SINE },
            { "Sine", WaveForm.WAVE_SINE },
            { "Sine 50Hz", WaveForm.WAVE_SINE_50Hz },
            { "Sine 1kHz", WaveForm.WAVE_SINE_1kHz },
            { "Squre", WaveForm.WAVE_SQURE },
            { "Custom", WaveForm.WAVE_CUSTOM },
        };

        public event EventHandler<double>DC_ValueChanged;
        public event EventHandler<WaveForm> WaveChanged;
        public event EventHandler Start;
        public event EventHandler Stop;

        string _title;
        [Category("KNV")]
        public string Title
        {
            get { return _title; }
            set 
            { 
                textBoxTitle.Text = value;
                labelTitle.Text = value;
                _title = value;
            }
        }

        [Category("KNV")]
        public string PhyName 
        {
            get { return labelPhyName.Text; }
            set { labelPhyName.Text = value;}
        }

        Color _color = SystemColors.Control;
        [Category("KNV")]
        public Color Channel
        {
            get { return _color; }
            set 
            {
                _color = value;
                labelPhyName.BackColor = value;
                labelTitle.BackColor = value;
                labelSettings.BackColor = value;
            }
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
                    SettingsChanged();
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
                labelDC.Text = $"{ao * Multiplier}{Unit}";
                textBoxRaw.Text = $"{ao:N2}V";
            }
        }

        [Category("KNV")]
        public WaveForm Wave
        {
            get
            {
                if (comboBoxWave.SelectedIndex != -1)
                {
                    int i = comboBoxWave.SelectedIndex;
                    return WaveList.Values.ToList()[i];
                }
                else
                    return WaveForm.WAVE_CUSTOM;
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
                if (i == -1)
                    return RunList.Values.ToList()[i];
                else
                    return WaveRunMode.RUN_SINGLE;
            }
            set
            {
                comboBoxRunMode.SelectedIndex = RunList.Values.ToList().IndexOf(value);
            }
        }

        [Category("KNV")]
        public double Amplitude 
        {
            get { return double.Parse(textBoxAmpl.Text); }
            set { textBoxAmpl.Text = value.ToString(); }
        }

        [Category("KNV")]
        public double Offset
        {
            get { return double.Parse(textBoxWaveOffset.Text); }
            set { textBoxWaveOffset.Text = value.ToString(); }
        }

        [Category("KNV")]
        public int DutyCycle
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
        public int Prescaler
        {
            get { return int.Parse(textBoxPrescaler.Text); }
            set { textBoxPrescaler.Text = value.ToString(); }
        }

        [Category("KNV")]
        public double PeriodTime 
        {
            set { textBoxPeriodTime.Text = value.ToString(); }
        }

        [Category("KNV")]
        public string SelctedTab
        {
            get { return tabControl1.SelectedTab.Name; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (tabControl1.TabPages.Cast<TabPage>().Select(x => x.Name).Contains(value))
                        tabControl1.SelectTab(value);
                }
            }
        }

        bool _init = false;

        void SettingsChanged()
        {
            double ao = trackBar1.Value / 10.0;
            labelDC.Text = $"{ao * Multiplier}{Unit}";
            textBoxRaw.Text = $"{ao:N2}V";
            labelSettings.Text = $"0..{10 * Multiplier} {Unit}";
        }

        public KnvAnalogOutputControl_v2()
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

            textBoxTitle.TextChanged += (o, e) =>
            {
                Title = textBoxTitle.Text;
                labelTitle.Text = textBoxTitle.Text;
            };

            textBoxMulti.TextChanged += (o, e) =>
            {
                if (double.TryParse(textBoxMulti.Text, out double value))
                {
                    textBoxMulti.BackColor = Color.White;
                    Multiplier = value;
                    SettingsChanged();
                }
                else
                {
                    textBoxMulti.BackColor = Color.Red;
                }
            };

            textBoxUnit.TextChanged += (o, e) =>
            {
                labelSettings.Text = $"0..{10 * Multiplier} {Unit}";
            };

            trackBar1.Scroll += (o, e) =>
            {
                double ao = trackBar1.Value / 10.0;
                labelDC.Text = $"{ao * Multiplier}{Unit}";
                textBoxRaw.Text = $"{ao:N2}V";
                DC_ValueChanged?.Invoke(this, ao);           
            };

            buttonStop.Click += (o, e) => 
            { 
                Stop?.Invoke(this, EventArgs.Empty); 
            };

            buttonStartStop.Click += (o, e) => 
            { 
                Start?.Invoke(this, EventArgs.Empty); 
            };
        }

        private void comboBoxWave_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_init)
                WaveChanged?.Invoke(this, Wave);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
