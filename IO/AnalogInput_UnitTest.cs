
namespace Knv.DAQ.IO
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.IO.Ports;
    using System.Linq;
    using System.Runtime.Remoting.Channels;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms.DataVisualization.Charting;

    [TestFixture]
    internal class AnalogInput_UnitTest
    {
        const string COM_PORT = "COM13";
        /*
         * 
         * AI:SAMP? 000F
         * FFFF
         * 
         * Samples(2dbyte)  Method                  BaudRate    Download Time
         * 4096             PollSampleBySample      115200      11417 ms
         * 4096             PollSampleBySample      230400      10210 ms
         * 4096             PollSampleBySample      460800       5203 ms
         * 4096             PollSampleBySample      921600       5325 ms
         * 1024             PollSampleBySample      460800       1424 ms
         * 1024             Poll - 256 byte Block   460800        354 ms
         * 
         */

        [Test]
        public void AdcResultDownload_PollSampleBySample()
        {
                    
            var sp = new SerialPort(COM_PORT, 460800, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.NewLine = "\r";
            sp.DtrEnable = true;
            sp.ReadTimeout = 1000;


            Func<string, string> io = (request) =>
            {
                sp.WriteLine(request);
                var response = sp.ReadLine();
                return response;
            };

            var idn = Identification(io);
            Assert.AreEqual("MPRT220416-ADC", idn);

            var ai = new AnalogInput(io);

            ai.SetConfiguration(1024, AnalogInput.AdcDivider.DIV_2, AnalogInput.TriggerSource.SOFTWARE);
            ai.SoftwareTrigger();

            long timestamp = DateTime.Now.Ticks;

            var samples = ai.SamplesDownload(1);
            Console.WriteLine($"Samples Download time is: {(DateTime.Now.Ticks - timestamp) / 10000} ms");


            var lines = new List<string>();
            samples.ToList().ForEach(x => lines.Add(x.ToString()));
            Save(lines);

            sp.Close();
        }


        [Test]
        public void AcqWithForm()
        {

            var sp = new SerialPort(COM_PORT, 460800, Parity.None, 8, StopBits.One);
            sp.Open();
            sp.NewLine = "\r";
            sp.DtrEnable = true;
            sp.ReadTimeout = 1000;

            Func<string, string> io = (request) =>
            {
                sp.WriteLine(request);
                var response = sp.ReadLine();
                return response;
            };

            var ai = new AnalogInput(io);
            ai.SetConfiguration(1024, AnalogInput.AdcDivider.DIV_8, AnalogInput.TriggerSource.SOFTWARE);
      
      

            var form = new PlotForm();
            var objChart = form.Chart.ChartAreas[0];

            //Time
            objChart.AxisX.IntervalType = DateTimeIntervalType.Number;
            objChart.AxisX.Minimum = 0;
            objChart.AxisX.Maximum = 1024;

            //Volts
            objChart.AxisY.IntervalType = DateTimeIntervalType.Number;
            objChart.AxisY.Minimum = 0;
            objChart.AxisY.Maximum = 10;

            var chart = form.Chart;

            chart.Series.Clear();

            string nameOfSeries = "Time-Voltage";
            chart.Series.Add(nameOfSeries);
            chart.Series[nameOfSeries].Color = System.Drawing.Color.Blue;
            chart.Series[nameOfSeries].Legend = "Legend1";
            chart.Series[nameOfSeries].ChartArea = "ChartArea1";
            chart.Series[nameOfSeries].ChartType = SeriesChartType.Line;

            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

            timer.Tick += (o1,e1) =>
            {         
                long timestamp = DateTime.Now.Ticks;
                ai.SoftwareTrigger();
                Thread.Sleep(50);
                var samples = ai.SamplesDownload(0);
                chart.Series[nameOfSeries].Points.Clear();

            for (int i = 0; i < samples.Length; i++)
            {
                var y = samples[i];
                chart.Series[nameOfSeries].Points.AddXY(i, y);
            }
            Console.WriteLine($"Samples Download time is: {(DateTime.Now.Ticks - timestamp) / 10000} ms");
            };

            timer.Start();     

            form.AcqDownload +=(o,e) => 
            {

            };

            form.ShowDialog();

            sp.Close();
                     
        }

        [Test]
        public void AcqTime()
        {
           var t_acq = AnalogInput.AcquisitionTimeMs(1024, AnalogInput.AdcDivider.DIV_8);
           Assert.AreEqual(30.9476, t_acq);
        }

        [Test]
        public void SamplingSpeed()
        {
            var smps = AnalogInput.SamplePerSec(AnalogInput.AdcDivider.DIV_8);
            Assert.AreEqual(132353, smps);
        }


        #region Tools

        void Save(List<string> lines)
        {
            var dt = DateTime.Now;
            var fileName = $"MPRT220416_ADC_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            using (var file = new StreamWriter($"{TestContext.CurrentContext.TestDirectory}\\{fileName}", true, Encoding.ASCII))
                lines.ForEach(file.WriteLine);
        }

        string Identification(Func<string, string> io)
        {
            var response = io("*IDN?");
            return response;
        }

        #endregion

    }
}