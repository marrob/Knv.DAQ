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

        //    knvAnalogOutputControl1.SetMode(WaveRunMode.WAVE_MODE_SINGLE);

            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {
             
                    knvAnalogOutputControl1.Wave = DaqIo.Instance.Ao1.SelectedWave();       
                    DaqIo.Instance.Ao1.ReadConfig();
                    knvAnalogOutputControl1.RunMode = DaqIo.Instance.Ao1.RunMode;
                    knvAnalogOutputControl1.WaveAmplitude = DaqIo.Instance.Ao1.Amplitude;
                    knvAnalogOutputControl1.WaveOffset = DaqIo.Instance.Ao1.Offset;
                    knvAnalogOutputControl1.WaveDutyCycle = DaqIo.Instance.Ao1.DutyCycle;
                    knvAnalogOutputControl1.SamplesCount = DaqIo.Instance.Ao1.SamplesCount;
                    knvAnalogOutputControl1.Divider = DaqIo.Instance.Ao1.Divider;

                    double ao1dc = DaqIo.Instance.Ao1.GetDC();
                    knvAnalogOutputControl1.Value = ao1dc;



                    knvAnalogOutputControl2.Wave = DaqIo.Instance.Ao2.SelectedWave();
                    DaqIo.Instance.Ao2.ReadConfig();

                    knvAnalogOutputControl2.RunMode = DaqIo.Instance.Ao2.RunMode;
                    knvAnalogOutputControl2.WaveAmplitude = DaqIo.Instance.Ao2.Amplitude;
                    knvAnalogOutputControl2.WaveOffset = DaqIo.Instance.Ao2.Offset;
                    knvAnalogOutputControl2.WaveDutyCycle = DaqIo.Instance.Ao2.DutyCycle;
                    knvAnalogOutputControl2.SamplesCount = DaqIo.Instance.Ao2.SamplesCount;
                    knvAnalogOutputControl2.Divider = DaqIo.Instance.Ao2.Divider;

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
            knvAnalogInputControl1.Title = Settings.Default.Ai1Title;
            knvAnalogInputControl1.Multiplier = Settings.Default.Ai1Multi;
            knvAnalogInputControl1.Offset = Settings.Default.Ai1Offset;
            knvAnalogInputControl1.Unit = Settings.Default.Ai1Unit;
            knvAnalogInputControl1.Samples = Settings.Default.Ai1Samples;

            knvAnalogInputControl2.Title = Settings.Default.Ai2Title;
            knvAnalogInputControl2.Multiplier = Settings.Default.Ai2Multi;
            knvAnalogInputControl2.Offset = Settings.Default.Ai2Offset;
            knvAnalogInputControl2.Unit = Settings.Default.Ai2Unit;
            knvAnalogInputControl2.Samples = Settings.Default.Ai2Samples;

            knvAnalogInputControl3.Title = Settings.Default.Ai3Title;
            knvAnalogInputControl3.Multiplier = Settings.Default.Ai3Multi;
            knvAnalogInputControl3.Offset = Settings.Default.Ai3Offset;
            knvAnalogInputControl3.Unit = Settings.Default.Ai3Unit;
            knvAnalogInputControl3.Samples = Settings.Default.Ai3Samples;

            knvAnalogInputControl4.Title = Settings.Default.Ai4Title;
            knvAnalogInputControl4.Multiplier = Settings.Default.Ai4Multi;
            knvAnalogInputControl4.Offset = Settings.Default.Ai4Offset;
            knvAnalogInputControl4.Unit = Settings.Default.Ai4Unit;
            knvAnalogInputControl4.Samples = Settings.Default.Ai4Samples;

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
            Settings.Default.Ai1Samples = knvAnalogInputControl1.Samples;

            Settings.Default.Ai2Title = knvAnalogInputControl2.Title;
            Settings.Default.Ai2Multi = knvAnalogInputControl2.Multiplier;
            Settings.Default.Ai2Offset = knvAnalogInputControl2.Offset;
            Settings.Default.Ai2Unit = knvAnalogInputControl2.Unit;
            Settings.Default.Ai2Samples = knvAnalogInputControl2.Samples;

            Settings.Default.Ai3Title = knvAnalogInputControl3.Title;
            Settings.Default.Ai3Multi = knvAnalogInputControl3.Multiplier;
            Settings.Default.Ai3Offset = knvAnalogInputControl3.Offset;
            Settings.Default.Ai3Unit = knvAnalogInputControl3.Unit;
            Settings.Default.Ai3Samples = knvAnalogInputControl3.Samples;

            Settings.Default.Ai4Title = knvAnalogInputControl4.Title;
            Settings.Default.Ai4Multi = knvAnalogInputControl4.Multiplier;
            Settings.Default.Ai4Offset = knvAnalogInputControl4.Offset;
            Settings.Default.Ai4Unit = knvAnalogInputControl4.Unit;
            Settings.Default.Ai4Samples = knvAnalogInputControl4.Samples;

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

        private void knvAnalogOutputControl2_ValueChanged(object sender, double voltage)
        {
            try
            {
                DaqIo.Instance.Ao2.SetDC(voltage);
            }
            catch (Exception ex)
            {
                DaqIo.Instance.TraceError($"Error:{ex.Message}");
            }
        }

        private void knvAnalogOutputControl1_ValueChanged(object sender, double voltage)
        {
            try
            {
                DaqIo.Instance.Ao1.SetDC(voltage);
            }
            catch (Exception ex)
            {
                DaqIo.Instance.TraceError($"Error:{ex.Message}");
            }
        }

        private void knvAnalogOutputControl1_Start(object sender, EventArgs e)
        {
            DaqIo.Instance.Ao1.SelectWave(knvAnalogOutputControl1.Wave);
            DaqIo.Instance.Ao1.RunMode = knvAnalogOutputControl1.RunMode;
            DaqIo.Instance.Ao1.Amplitude = knvAnalogOutputControl1.WaveAmplitude;
            DaqIo.Instance.Ao1.Offset = knvAnalogOutputControl1.WaveOffset;
            DaqIo.Instance.Ao1.DutyCycle = knvAnalogOutputControl1.WaveDutyCycle;
            DaqIo.Instance.Ao1.SamplesCount = knvAnalogOutputControl1.SamplesCount;
            DaqIo.Instance.Ao1.Divider = knvAnalogOutputControl1.Divider;
            DaqIo.Instance.Ao1.Start();

        }

        private void knvAnalogOutputControl1_Stop(object sender, EventArgs e)
        {
            DaqIo.Instance.Ao1.Stop();
        }

        private void knvAnalogOutputControl2_Start(object sender, EventArgs e)
        {
            DaqIo.Instance.Ao2.SelectWave(knvAnalogOutputControl2.Wave);
            DaqIo.Instance.Ao2.RunMode = knvAnalogOutputControl2.RunMode;
            DaqIo.Instance.Ao2.Amplitude = knvAnalogOutputControl2.WaveAmplitude;
            DaqIo.Instance.Ao2.Offset = knvAnalogOutputControl2.WaveOffset;
            DaqIo.Instance.Ao2.DutyCycle = knvAnalogOutputControl2.WaveDutyCycle;
            DaqIo.Instance.Ao2.SamplesCount = knvAnalogOutputControl2.SamplesCount;
            DaqIo.Instance.Ao2.Divider = knvAnalogOutputControl2.Divider;
            DaqIo.Instance.Ao2.Start();
        }

        private void knvAnalogOutputControl2_Stop(object sender, EventArgs e)
        {
            DaqIo.Instance.Ao2.Stop();
        }

        private void knvAnalogOutputControl1_WaveChanged(object sender, WaveForm e)
        {
            DaqIo.Instance.Ao1.SelectWave(e);
            DaqIo.Instance.Ao1.ReadConfig();

            knvAnalogOutputControl1.RunMode = DaqIo.Instance.Ao1.RunMode;
            knvAnalogOutputControl1.WaveAmplitude = DaqIo.Instance.Ao1.Amplitude;
            knvAnalogOutputControl1.WaveOffset = DaqIo.Instance.Ao1.Offset;
            knvAnalogOutputControl1.WaveDutyCycle = DaqIo.Instance.Ao1.DutyCycle;
            knvAnalogOutputControl1.SamplesCount = DaqIo.Instance.Ao1.SamplesCount;
            knvAnalogOutputControl1.Divider = DaqIo.Instance.Ao1.Divider;

            
        }

        private void knvAnalogOutputControl2_WaveChanged(object sender, WaveForm e)
        {
            DaqIo.Instance.Ao2.SelectWave(e);
            DaqIo.Instance.Ao2.ReadConfig();

            knvAnalogOutputControl2.RunMode = DaqIo.Instance.Ao2.RunMode;
            knvAnalogOutputControl2.WaveAmplitude = DaqIo.Instance.Ao2.Amplitude;
            knvAnalogOutputControl2.WaveOffset = DaqIo.Instance.Ao2.Offset;
            knvAnalogOutputControl2.WaveDutyCycle = DaqIo.Instance.Ao2.DutyCycle;
            knvAnalogOutputControl2.SamplesCount = DaqIo.Instance.Ao2.SamplesCount;
            knvAnalogOutputControl2.Divider = DaqIo.Instance.Ao2.Divider;
        }
    }
}
