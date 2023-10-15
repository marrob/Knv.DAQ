

namespace Knv.Fan.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;

    class UpTime : ToolStripStatusLabel
    { 
        public UpTime()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = "UpTime Counter: " + AppConstants.ValueNotAvailable2;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Start();

            timer.Tick += (s, e) =>
            {
                if (SerialIo.Instance.IsOpen)
                {
                    Text = "UpTime Counter: " + SerialIo.Instance.GetUpTime();
                }
            };
        }
    }
}
