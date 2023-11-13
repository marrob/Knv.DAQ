
namespace Knv.DAQ.Commands
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using Properties;
    using Events;



    class TraceingEnableCommand : ToolStripMenuItem
    {
        public TraceingEnableCommand()
        {
            Text = "Tracing";
            ShortcutKeys = Keys.F7;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {
                DaqIo.Instance.TracingEnable = Settings.Default.TracingEnable;
                Checked = DaqIo.Instance.TracingEnable;

                if (Checked)
                {
                    BackColor = Color.Orange;
                    Text = $"Tracing Enabled";
                }
                else
                {
                    BackColor = SystemColors.Control;
                    Text = $"Tracing";
                }
            }));

        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            Settings.Default.TracingEnable = !Settings.Default.TracingEnable;
            DaqIo.Instance.TracingEnable = Settings.Default.TracingEnable;

            Checked = DaqIo.Instance.TracingEnable;
            if (Checked)
            {
                BackColor = Color.Orange;
                Text = $"Tracing Enabled";
            }
            else
            {
                BackColor = SystemColors.Control;
                Text = $"Tracing";
            }
        }
    }
}
