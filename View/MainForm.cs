namespace Knv.DAQ
{
    using System.Windows.Forms;
    using Controls;
    using System;
    using Events;
    using Knv.DAQ.Properties;
    using IO;
    public interface IMainForm
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        bool AlwaysOnTop { get; set; }
        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        ToolStripItem[] StatusBar { set; }
        KnvTracingControl Tracing { get; }

        bool TracingVisible { get; set; }
    }

    public partial class MainForm : Form , IMainForm
    {
        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public KnvTracingControl Tracing
        {
            get { return knvTracingControl1; }
        }

        public bool AlwaysOnTop
        {
            get { return this.TopMost; }
            set { this.TopMost = value; }
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public bool TracingVisible 
        {
            get { return splitContainer1.Panel2Collapsed; }
            set { splitContainer1.Panel2Collapsed = !value; }
        }

        public MainForm()
        {
            InitializeComponent();

            knvAnalogOutputControl1.PhyName = "AO1";
            knvAnalogOutputControl2.PhyName = "AO2";

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {
             
                    knvAnalogOutputControl1.Wave = DaqIo.Instance.Ao1.SelectedWave();       
                    DaqIo.Instance.Ao1.ReadConfig();
                    knvAnalogOutputControl1.RunMode = DaqIo.Instance.Ao1.RunMode;
                    knvAnalogOutputControl1.Amplitude = DaqIo.Instance.Ao1.Amplitude;
                    knvAnalogOutputControl1.Offset = DaqIo.Instance.Ao1.Offset;
                    knvAnalogOutputControl1.DutyCycle = DaqIo.Instance.Ao1.DutyCycle;
                    knvAnalogOutputControl1.SamplesCount = DaqIo.Instance.Ao1.SamplesCount;
                    knvAnalogOutputControl1.Prescaler = DaqIo.Instance.Ao1.Prescaler;
                    knvAnalogOutputControl1.PeriodTime = DaqIo.Instance.Ao1.PeriodTime;

                    double ao1dc = DaqIo.Instance.Ao1.GetDC();
                    knvAnalogOutputControl1.Value = ao1dc;

                    knvAnalogOutputControl2.Wave = DaqIo.Instance.Ao2.SelectedWave();
                    DaqIo.Instance.Ao2.ReadConfig();

                    knvAnalogOutputControl2.RunMode = DaqIo.Instance.Ao2.RunMode;
                    knvAnalogOutputControl2.Amplitude = DaqIo.Instance.Ao2.Amplitude;
                    knvAnalogOutputControl2.Offset = DaqIo.Instance.Ao2.Offset;
                    knvAnalogOutputControl2.DutyCycle = DaqIo.Instance.Ao2.DutyCycle;
                    knvAnalogOutputControl2.SamplesCount = DaqIo.Instance.Ao2.SamplesCount;
                    knvAnalogOutputControl2.Prescaler = DaqIo.Instance.Ao2.Prescaler;
                    knvAnalogOutputControl2.PeriodTime = DaqIo.Instance.Ao2.PeriodTime;

                    double ao2dc = DaqIo.Instance.Ao2.GetDC();
                    knvAnalogOutputControl2.Value = ao2dc;
                }
            }));


            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                splitContainer1.Panel1.Enabled = e.IsOpen;
            }));

            timerSampling.Start();
        }

        private void timerSampling_Tick(object sender, EventArgs e)
        {
            if (DaqIo.Instance.IsOpen)
            {
                try
                {
                    var ai1 = DaqIo.Instance.Ai1;
                    var ai2 = DaqIo.Instance.Ai2;
                    var ai3 = DaqIo.Instance.Ai3;
                    var ai4 = DaqIo.Instance.Ai4;
           
                   knvAnalogInputControl1.AddSample(ai1);
                   knvAnalogInputControl2.AddSample(ai2);
                   knvAnalogInputControl3.AddSample(ai3);
                   knvAnalogInputControl4.AddSample(ai4);
                }
                catch (Exception ex)
                {
                    DaqIo.Instance.TraceError($"Error:{ex.Message}");
                }
            }
        }

        private void LoadSettings()
        {

            knvAnalogInputControl1.SelctedTab = Settings.Default.Ai1SelectedTab;
            knvAnalogInputControl1.PhyName = "AI1";
            knvAnalogInputControl1.Channel = System.Drawing.Color.Yellow;
            knvAnalogInputControl1.Title = Settings.Default.Ai1Title;
            knvAnalogInputControl1.Multiplier = Settings.Default.Ai1Multi;
            knvAnalogInputControl1.Offset = Settings.Default.Ai1Offset;
            knvAnalogInputControl1.Unit = Settings.Default.Ai1Unit;

            knvAnalogInputControl2.SelctedTab = Settings.Default.Ai2SelectedTab;
            knvAnalogInputControl2.PhyName = "AI2";
            knvAnalogInputControl2.Channel = System.Drawing.Color.Green;
            knvAnalogInputControl2.Title = Settings.Default.Ai2Title;
            knvAnalogInputControl2.Multiplier = Settings.Default.Ai2Multi;
            knvAnalogInputControl2.Offset = Settings.Default.Ai2Offset;
            knvAnalogInputControl2.Unit = Settings.Default.Ai2Unit;

            knvAnalogInputControl3.SelctedTab = Settings.Default.Ai3SelectedTab;
            knvAnalogInputControl3.PhyName = "AI3";
            knvAnalogInputControl3.Channel = System.Drawing.Color.Pink;
            knvAnalogInputControl3.Title = Settings.Default.Ai3Title;
            knvAnalogInputControl3.Multiplier = Settings.Default.Ai3Multi;
            knvAnalogInputControl3.Offset = Settings.Default.Ai3Offset;
            knvAnalogInputControl3.Unit = Settings.Default.Ai3Unit;

            knvAnalogInputControl4.SelctedTab = Settings.Default.Ai4SelectedTab;
            knvAnalogInputControl4.PhyName = "AI4";
            knvAnalogInputControl4.Channel = System.Drawing.Color.Purple;
            knvAnalogInputControl4.Title = Settings.Default.Ai4Title;
            knvAnalogInputControl4.Multiplier = Settings.Default.Ai4Multi;
            knvAnalogInputControl4.Offset = Settings.Default.Ai4Offset;
            knvAnalogInputControl4.Unit = Settings.Default.Ai4Unit;


            knvAnalogOutputControl1.SelctedTab = Settings.Default.Ao1SelectedTab;
            knvAnalogOutputControl1.Title = Settings.Default.Ao1Title;
            knvAnalogOutputControl1.Multiplier = Settings.Default.Ao1Multi;
            knvAnalogOutputControl1.Unit = Settings.Default.Ao1Unit;

            knvAnalogOutputControl2.SelctedTab = Settings.Default.Ao2SelectedTab;
            knvAnalogOutputControl2.Title = Settings.Default.Ao2Title;
            knvAnalogOutputControl2.Multiplier = Settings.Default.Ao2Multi;
            knvAnalogOutputControl2.Unit = Settings.Default.Ao2Unit;


            if (Settings.Default.WindowLocation.X > 0 && Settings.Default.WindowLocation.Y > 0)
                this.Location = Settings.Default.WindowLocation;

            if(Settings.Default.WindowSize.Width > 0 && Settings.Default.WindowSize.Height > 0)
                this.Size = Settings.Default.WindowSize;


            knvAnalogOutputControl1.DC_ValueChanged += (o, volts) =>
            {
                try
                {
                    DaqIo.Instance.Ao1.SetDC(volts);
                }
                catch (Exception ex)
                {
                    DaqIo.Instance.TraceError($"Error:{ex.Message}");
                }
            };

            knvAnalogOutputControl1.WaveChanged += (o, wave) =>
            {
                DaqIo.Instance.Ao1.SelectWave(wave);
                DaqIo.Instance.Ao1.ReadConfig();

                knvAnalogOutputControl1.RunMode = DaqIo.Instance.Ao1.RunMode;
                knvAnalogOutputControl1.Amplitude = DaqIo.Instance.Ao1.Amplitude;
                knvAnalogOutputControl1.Offset = DaqIo.Instance.Ao1.Offset;
                knvAnalogOutputControl1.DutyCycle = DaqIo.Instance.Ao1.DutyCycle;
                knvAnalogOutputControl1.SamplesCount = DaqIo.Instance.Ao1.SamplesCount;
                knvAnalogOutputControl1.Prescaler = DaqIo.Instance.Ao1.Prescaler;
                knvAnalogOutputControl1.PeriodTime = DaqIo.Instance.Ao1.PeriodTime;
            };

            knvAnalogOutputControl1.Start += (o, e) =>
            {
                DaqIo.Instance.Ao1.SelectWave(knvAnalogOutputControl1.Wave);
                DaqIo.Instance.Ao1.RunMode = knvAnalogOutputControl1.RunMode;
                DaqIo.Instance.Ao1.Amplitude = knvAnalogOutputControl1.Amplitude;
                DaqIo.Instance.Ao1.Offset = knvAnalogOutputControl1.Offset;
                DaqIo.Instance.Ao1.DutyCycle = knvAnalogOutputControl1.DutyCycle;
                DaqIo.Instance.Ao1.SamplesCount = knvAnalogOutputControl1.SamplesCount;
                DaqIo.Instance.Ao1.Prescaler = knvAnalogOutputControl1.Prescaler;
                DaqIo.Instance.Ao1.Start();
            };

            knvAnalogOutputControl1.Stop += (o, e) =>
            {
                DaqIo.Instance.Ao1.Stop();
            };

            knvAnalogOutputControl2.DC_ValueChanged += (o, volts) =>
            {
                try
                {
                    DaqIo.Instance.Ao2.SetDC(volts);
                }
                catch (Exception ex)
                {
                    DaqIo.Instance.TraceError($"Error:{ex.Message}");
                }
            };

            knvAnalogOutputControl2.WaveChanged += (o, wave) =>
            {
                DaqIo.Instance.Ao2.SelectWave(wave);
                DaqIo.Instance.Ao2.ReadConfig();

                knvAnalogOutputControl2.RunMode = DaqIo.Instance.Ao2.RunMode;
                knvAnalogOutputControl2.Amplitude = DaqIo.Instance.Ao2.Amplitude;
                knvAnalogOutputControl2.Offset = DaqIo.Instance.Ao2.Offset;
                knvAnalogOutputControl2.DutyCycle = DaqIo.Instance.Ao2.DutyCycle;
                knvAnalogOutputControl2.SamplesCount = DaqIo.Instance.Ao2.SamplesCount;
                knvAnalogOutputControl2.Prescaler = DaqIo.Instance.Ao2.Prescaler;

                knvAnalogOutputControl2.PeriodTime = DaqIo.Instance.Ao2.PeriodTime;
            };

            knvAnalogOutputControl2.Start += (o, e) =>
            {
                DaqIo.Instance.Ao2.SelectWave(knvAnalogOutputControl1.Wave);
                DaqIo.Instance.Ao2.RunMode = knvAnalogOutputControl1.RunMode;
                DaqIo.Instance.Ao2.Amplitude = knvAnalogOutputControl1.Amplitude;
                DaqIo.Instance.Ao2.Offset = knvAnalogOutputControl1.Offset;
                DaqIo.Instance.Ao2.DutyCycle = knvAnalogOutputControl1.DutyCycle;
                DaqIo.Instance.Ao2.SamplesCount = knvAnalogOutputControl1.SamplesCount;
                DaqIo.Instance.Ao2.Prescaler = knvAnalogOutputControl1.Prescaler;
                DaqIo.Instance.Ao2.Start();
            };

            knvAnalogOutputControl2.Stop += (o, e) =>
            {
                DaqIo.Instance.Ao2.Stop();
            };
        }

        private void SaveSettings()
        {

            Settings.Default.Ai1SelectedTab = knvAnalogInputControl1.SelctedTab;
            Settings.Default.Ai1Title = knvAnalogInputControl1.Title;
            Settings.Default.Ai1Multi = knvAnalogInputControl1.Multiplier;
            Settings.Default.Ai1Offset = knvAnalogInputControl1.Offset;
            Settings.Default.Ai1Unit = knvAnalogInputControl1.Unit;

            Settings.Default.Ai2SelectedTab = knvAnalogInputControl2.SelctedTab;
            Settings.Default.Ai2Title = knvAnalogInputControl2.Title;
            Settings.Default.Ai2Multi = knvAnalogInputControl2.Multiplier;
            Settings.Default.Ai2Offset = knvAnalogInputControl2.Offset;
            Settings.Default.Ai2Unit = knvAnalogInputControl2.Unit;

            Settings.Default.Ai3SelectedTab = knvAnalogInputControl3.SelctedTab;
            Settings.Default.Ai3Title = knvAnalogInputControl3.Title;
            Settings.Default.Ai3Multi = knvAnalogInputControl3.Multiplier;
            Settings.Default.Ai3Offset = knvAnalogInputControl3.Offset;
            Settings.Default.Ai3Unit = knvAnalogInputControl3.Unit;

            Settings.Default.Ai4SelectedTab = knvAnalogInputControl4.SelctedTab;
            Settings.Default.Ai4Title = knvAnalogInputControl4.Title;
            Settings.Default.Ai4Multi = knvAnalogInputControl4.Multiplier;
            Settings.Default.Ai4Offset = knvAnalogInputControl4.Offset;
            Settings.Default.Ai4Unit = knvAnalogInputControl4.Unit;

            Settings.Default.Ao1SelectedTab = knvAnalogOutputControl1.SelctedTab;
            Settings.Default.Ao1Title = knvAnalogOutputControl1.Title;
            Settings.Default.Ao1Multi = knvAnalogOutputControl1.Multiplier;
            Settings.Default.Ao1Unit = knvAnalogOutputControl1.Unit;

            Settings.Default.Ao2SelectedTab = knvAnalogOutputControl2.SelctedTab;
            Settings.Default.Ao2Title = knvAnalogOutputControl2.Title;
            Settings.Default.Ao2Multi = knvAnalogOutputControl2.Multiplier;
            Settings.Default.Ao2Unit = knvAnalogOutputControl2.Unit;

            Settings.Default.WindowLocation = this.Location;
            Settings.Default.WindowSize = this.Size;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveSettings();
        }
    }
}
