namespace Knv.DAQ
{
    using System.Windows.Forms;
    using Controls;
    using System;
    using Events;
    using Knv.DAQ.Properties;

    public interface IMainForm
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

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
            get
            {
                return knvTracingControl1;
            }
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

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {
                   double ao1 = DaqIo.Instance.Ao1;
                   knvAnalogOutputControl1.Value = ao1;

                   double ao2 = DaqIo.Instance.Ao2;
                   knvAnalogOutputControl2.Value = ao2;
                }
            }));


            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                Enabled = e.IsOpen;
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
            knvAnalogInputControl1.Title = Settings.Default.Ai1Title;
            knvAnalogInputControl1.Multiplier = Settings.Default.Ai1Multi;
            knvAnalogInputControl1.Offset = Settings.Default.Ai1Offset;
            knvAnalogInputControl1.Unit = Settings.Default.Ai1Unit;

            knvAnalogInputControl2.Title = Settings.Default.Ai2Title;
            knvAnalogInputControl2.Multiplier = Settings.Default.Ai2Multi;
            knvAnalogInputControl2.Offset = Settings.Default.Ai2Offset;
            knvAnalogInputControl2.Unit = Settings.Default.Ai2Unit;

            knvAnalogInputControl3.Title = Settings.Default.Ai3Title;
            knvAnalogInputControl3.Multiplier = Settings.Default.Ai3Multi;
            knvAnalogInputControl3.Offset = Settings.Default.Ai3Offset;
            knvAnalogInputControl3.Unit = Settings.Default.Ai3Unit;

            knvAnalogInputControl4.Title = Settings.Default.Ai4Title;
            knvAnalogInputControl4.Multiplier = Settings.Default.Ai4Multi;
            knvAnalogInputControl4.Offset = Settings.Default.Ai4Offset;
            knvAnalogInputControl4.Unit = Settings.Default.Ai4Unit;

            knvAnalogOutputControl1.Title = Settings.Default.Ao1Title;
            knvAnalogOutputControl1.Multiplier = Settings.Default.Ao1Multi;
            knvAnalogOutputControl1.Offset = Settings.Default.Ao1Offset;
            knvAnalogOutputControl1.Unit = Settings.Default.Ao1Unit;

            knvAnalogOutputControl2.Title = Settings.Default.Ao2Title;
            knvAnalogOutputControl2.Multiplier = Settings.Default.Ao2Multi;
            knvAnalogOutputControl2.Offset = Settings.Default.Ao2Offset;
            knvAnalogOutputControl2.Unit = Settings.Default.Ao2Unit;

            numericUpDownSPS.Value = Settings.Default.SamplePerSec;


            if (Settings.Default.WindowLocation.X > 0 && Settings.Default.WindowLocation.Y > 0)
                this.Location = Settings.Default.WindowLocation;

            if(Settings.Default.WindowSize.Width > 0 && Settings.Default.WindowSize.Height > 0)
                this.Size = Settings.Default.WindowSize;
        }

        private void SaveSettings()
        {
            Settings.Default.Ai1Title = knvAnalogInputControl1.Title;
            Settings.Default.Ai1Multi = knvAnalogInputControl1.Multiplier;
            Settings.Default.Ai1Offset = knvAnalogInputControl1.Offset;
            Settings.Default.Ai1Unit = knvAnalogInputControl1.Unit;

            Settings.Default.Ai2Title = knvAnalogInputControl2.Title;
            Settings.Default.Ai2Multi = knvAnalogInputControl2.Multiplier;
            Settings.Default.Ai2Offset = knvAnalogInputControl2.Offset;
            Settings.Default.Ai2Unit = knvAnalogInputControl2.Unit;

            Settings.Default.Ai3Title = knvAnalogInputControl3.Title;
            Settings.Default.Ai3Multi = knvAnalogInputControl3.Multiplier;
            Settings.Default.Ai3Offset = knvAnalogInputControl3.Offset;
            Settings.Default.Ai3Unit = knvAnalogInputControl3.Unit;

            Settings.Default.Ai4Title = knvAnalogInputControl4.Title;
            Settings.Default.Ai4Multi = knvAnalogInputControl4.Multiplier;
            Settings.Default.Ai4Offset = knvAnalogInputControl4.Offset;
            Settings.Default.Ai4Unit = knvAnalogInputControl4.Unit;

            Settings.Default.Ao1Title = knvAnalogOutputControl1.Title;
            Settings.Default.Ao1Multi = knvAnalogOutputControl1.Multiplier;
            Settings.Default.Ao1Offset = knvAnalogOutputControl1.Offset;
            Settings.Default.Ao1Unit = knvAnalogOutputControl1.Unit;

            Settings.Default.Ao2Title = knvAnalogOutputControl2.Title;
            Settings.Default.Ao2Multi = knvAnalogOutputControl2.Multiplier;
            Settings.Default.Ao2Offset = knvAnalogOutputControl2.Offset;
            Settings.Default.Ao2Unit = knvAnalogOutputControl2.Unit;


            Settings.Default.SamplePerSec = (int)numericUpDownSPS.Value;

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

        private void numericUpDownSPS_ValueChanged(object sender, EventArgs e)
        {
            timerSampling.Interval = (int)(1.0/(double)numericUpDownSPS.Value * 1000);
        }

        private void knvAnalogOutputControl2_ValueChanged(object sender, double e)
        {
            try
            {
                 DaqIo.Instance.Ao2 = e;
            }
            catch (Exception ex)
            {
                DaqIo.Instance.TraceError($"Error:{ex.Message}");
            }
        }

        private void knvAnalogOutputControl1_ValueChanged(object sender, double e)
        {
            try
            {
                 DaqIo.Instance.Ao1 = e;
            }
            catch (Exception ex)
            {
                DaqIo.Instance.TraceError($"Error:{ex.Message}");
            }
        }
    }
}
