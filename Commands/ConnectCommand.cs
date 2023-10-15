
namespace Knv.Fan.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;

    class ConnectCommand : ToolStripMenuItem
    {
        public ConnectCommand(/*App app*/)
        {
            Text = "Connect";
            //Image = Resources.Play_Hot48;
            ShortcutKeys = Keys.F7;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;
            EventAggregator.Instance.Subscribe((Action<ConnectionChangedAppEvent>)(e =>
            {
                if (e.IsOpen)
                {
                    Text = "Disconnect";
                    //Image = Resources.Stop_Normal_Red48;
                }
                else
                {
                    Text = "Connect";
                    //Image = Resources.Play_Hot48;
                }
            }));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(SerialIo.Instance.IsOpen)
                 SerialIo.Instance.Close();
            else
                SerialIo.Instance.Open(Settings.Default.SeriaPortName);
               
        }
    }
}
