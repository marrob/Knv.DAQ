
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
    using System.Text;

    [TestFixture]
    internal class MPRT220416_ADC_FW_UnitTest
    {
        const string COM_PORT = "COM13";

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

            var resp = "";

            const int SAMPLE_COUNT = 1024;
            var samples = new List<int>();
            long timestamp = DateTime.Now.Ticks;
            for (int i = 0; i < SAMPLE_COUNT; i++)
            {
                resp = io($"AI:SMP? {i:X4}");
                samples.Add(int.Parse(resp, NumberStyles.AllowHexSpecifier, CultureInfo.GetCultureInfo("en-US")));
            }

            Console.WriteLine($"ADC Data Download Time: {(DateTime.Now.Ticks - timestamp) / 10000} ms");

            var lines = new List<string>();
            samples.ForEach(x => lines.Add(x.ToString()));
            var dt = DateTime.Now;
            var fileName = $"MPRT220416_ADC_{dt:yyyy}{dt:MM}{dt:dd}_{dt:HH}{dt:mm}{dt:ss}.csv";
            using (var file = new StreamWriter($"{TestContext.CurrentContext.TestDirectory}\\{fileName}", true, Encoding.ASCII))
                lines.ForEach(file.WriteLine);

            sp.Close();
        }

        string Identification(Func<string, string> io)
        {
            var response = io("*IDN?");
            return response;
        }

    }
}