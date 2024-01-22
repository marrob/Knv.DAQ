namespace Knv.DAQ.StatusBar
{
    using System;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using IO;

    class FwVersion : ToolStripStatusLabel
    { 
        public FwVersion()
        {
            BorderSides = ToolStripStatusLabelBorderSides.Left;
            BorderStyle = Border3DStyle.Etched;
            Size = new System.Drawing.Size(58, 19);
            Text = AppConstants.ValueNotAvailable2;
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                   Text = DaqIo.Instance.GetVersion();
                else
                    Text = AppConstants.ValueNotAvailable2;
            }));
        }
    }
}
