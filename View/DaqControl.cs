
namespace Knv.DAQ.View
{
    using Knv.DAQ.Events;
    using System;
    using System.Windows.Forms;

    public partial class DaqControl : UserControl
    {

        Timer _samplingTimer = new Timer();

        public DaqControl()
        {
            InitializeComponent();

            textBoxAO1.Text = 0.ToString();
            textBoxAO2.Text = 0.ToString();


            buttonReset_Click(null, EventArgs.Empty);

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

            var samplePerSec = 1;
            numericUpDownSPS.Value = samplePerSec;
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
                    knvMovingChartAO1.AddSample(ai1);
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
            _samplingTimer.Interval = (int)(1.0/(double)numericUpDownSPS.Value * 1000);
        }
    }
}
