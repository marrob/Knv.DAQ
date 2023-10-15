using Knv.Fan.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;


namespace Knv.Fun.View
{
    using Knv.Fan;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class FanControl : UserControl
    {
        public FanControl()
        {
            InitializeComponent();


            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen) 
                {
                    if (SerialIo.Instance.PwmDutyCycle < trackBar1.Maximum)
                        trackBar1.Value = SerialIo.Instance.PwmDutyCycle;

                    textBoxFrequency.Text = SerialIo.Instance.PwmFrequency.ToString();
                }
            }));


            Timer timer = new Timer();
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();

            timer.Tick += (o, e) =>
            {

                if(SerialIo.Instance.IsOpen) 
                {

                    double vntc = SerialIo.Instance.AIN0;
                    textBoxAIN0.Text = vntc.ToString();
                    double current = (3.3 - vntc) / 2200.0;
                    textBoxCurr.Text = Math.Round(current * 1000,3).ToString();
                    double ntc = vntc / current;
                    ntc += 150; 
                    textBoxRes.Text = Math.Round(ntc,2).ToString();

                    var a = 3.354016E-03;
                    var b = 2.569850E-04;
                    var c = 2.620131E-06;
                    var d = 6.383091E-08;
                    var ref25 = 2200;
                    double temp = CalculateTemperatureCelsius(ntc/ref25, a, b, c, d);

                    textBoxTemp.Text = temp.ToString();

                    textBoxAIN1.Text = SerialIo.Instance.AIN1.ToString();
                    textBoxAIN2.Text = SerialIo.Instance.AIN2.ToString();
                }
            };
        }

        public static double CalculateTemperatureCelsius(double resistance, double a, double b, double c, double d)
        {
            //https://en.wikipedia.org/wiki/Steinhart%E2%80%93Hart_equation
            double lnR = Math.Log(resistance);
            double reciprocal = 1.0 / (a + b * lnR + c * Math.Pow(lnR, 2) + d * Math.Pow(lnR, 3));
            double temperatureKelvin = reciprocal;
            double temperatureCelsius = temperatureKelvin - 273.15;
            return temperatureCelsius;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            if(SerialIo.Instance.IsOpen)
            {
                SerialIo.Instance.PwmDutyCycle = trackBar1.Value;
            }
        }
    }
}
