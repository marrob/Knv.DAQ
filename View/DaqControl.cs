
namespace Knv.DAQ.View
{
    using Knv.DAQ.Events;
    using Knv.DAQ.Properties;
    using System;
    using System.Windows.Forms;

    public partial class DaqControl : UserControl
    {

        readonly Timer _samplingTimer = new Timer();

        public DaqControl()
        {
            InitializeComponent();

            textBoxAO1.Text = 0.ToString();
            textBoxAO2.Text = 0.ToString();

            buttonReset_Click(null, EventArgs.Empty);

            textBoxAI1Title.Text = Settings.Default.AI1Title;
            textBoxAI1Multiplier.Text = Settings.Default.AI1Multiplier.ToString("N3");
            textBoxAI1Offset.Text = Settings.Default.AI1Offset.ToString("N3");


            //Vertical Axis Maximum: 10V * Multiplier + Offset
            knvMovingChartAO1.VerticalMaximum = 10 * Settings.Default.AI1Multiplier + Settings.Default.AI1Offset;


            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen) 
                {
                    double ao1 = DaqIo.Instance.AO1;
                    textBoxAO1.Text = ao1.ToString();
                    trackBarAO1.Value = (int)ao1;

                    double ao2 = DaqIo.Instance.AO2;
                    textBoxAO2.Text = ao2.ToString();
                    trackBarAO2.Value = (int)ao2;
                }
            }));


            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                Enabled = e.IsOpen;
            }));

            numericUpDownSPS.Value = Settings.Default.SamplePerSec;
            _samplingTimer.Interval = (int)(1.0 / (double)numericUpDownSPS.Value * 1000);
            _samplingTimer.Enabled = true;
            _samplingTimer.Start();
            _samplingTimer.Tick += SamplingTimer_Tick;
        }

        private void SamplingTimer_Tick(object sender, EventArgs e)
        {
            if (DaqIo.Instance.IsOpen)
            {
                try
                {
                    var ai1 = DaqIo.Instance.AI1;
                    var ai2 = DaqIo.Instance.AI2;
                    var ai3 = DaqIo.Instance.AI3;
                    var ai4 = DaqIo.Instance.AI4;

                    textBoxAI1.Text = ai1.ToString();

                    var customAi1 = ai1 * Settings.Default.AI1Multiplier + Settings.Default.AI1Offset;

                    AI1CustomValue.Text = customAi1.ToString("N2");
                    knvMovingChartAO1.AddSample(customAi1);

                    textBoxAI2.Text = ai2.ToString();
                    knvMovingChartAO2.AddSample(ai2);
                    textBoxAI3.Text = ai3.ToString();
                    knvMovingChartAO3.AddSample(ai3);
                    textBoxAI4.Text = ai4.ToString();
                    knvMovingChartAO4.AddSample(ai4);
                }
                catch (Exception ex)
                {
                    DaqIo.Instance.TraceError($"Error:{ex.Message}");
                }
            }
        }

        private void trackBarAO1_Scroll(object sender, EventArgs e)
        {
            try
            {
                double ao1 = trackBarAO1.Value / 10.0;
                textBoxAO1.Text = ao1.ToString();
                DaqIo.Instance.AO1 = ao1;
            }
            catch (Exception ex)
            {
                DaqIo.Instance.TraceError($"Error:{ex.Message}");
            }
        }

        private void trackBarAO2_Scroll(object sender, EventArgs e)
        {
            try
            {
                double ao2 = trackBarAO2.Value / 10.0;
                textBoxAO2.Text = ao2.ToString();
                DaqIo.Instance.AO2 = ao2;
            }
            catch (Exception ex) 
            {
                DaqIo.Instance.TraceError($"Error:{ex.Message}");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            knvMovingChartAO1.Reset();
            knvMovingChartAO2.Reset();
            knvMovingChartAO3.Reset();
            knvMovingChartAO4.Reset();
        }

        private void numericUpDownSPS_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.SamplePerSec = (int)numericUpDownSPS.Value;
            _samplingTimer.Interval = (int)(1.0/(double)numericUpDownSPS.Value * 1000);
            Settings.Default.Save();
        }

        private void textBoxAI1Multiplier_Validated(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxAI1Multiplier.Text, out double value))
            { 
                Settings.Default.AI1Multiplier = value; 
                Settings.Default.Save();
            }
        }

        private void textBoxAI1Title_Validated(object sender, EventArgs e)
        {
            Settings.Default.AI1Title = textBoxAI1Title.Text;
            Settings.Default.Save();
        }
    }
}
