
namespace Knv.DAQ.Commands
{
    using System;
    using System.Diagnostics;
    using System.Windows.Forms;
    using Properties;
    using Events;
    using System.Drawing;

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
                    BackColor = Color.Orange;
                    //Image = Resources.Stop_Normal_Red48;
                }
                else
                {
                    Text = "Connect";
                    BackColor = SystemColors.Control;
                    //Image = Resources.Play_Hot48;
                }
            }));
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if(DaqIo.Instance.IsOpen)
                 DaqIo.Instance.Close();
            else
                DaqIo.Instance.Open(Settings.Default.SeriaPortName);
               
        }
    }
}
