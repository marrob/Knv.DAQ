
namespace Knv.DAQ.Commands
{
    using System;
    using System.Windows.Forms;
    using System.Drawing;
    using Properties;
    using Events;



    class TraceingEnableCommand : ToolStripMenuItem
    {
       
        readonly IMainForm _mainForm;
        public TraceingEnableCommand(IMainForm mainForm)
        {
            Text = "Tracing";
            ShortcutKeys = Keys.F7;
            DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
            Enabled = true;
            _mainForm = mainForm;

            EventAggregator.Instance.Subscribe((Action<ShowAppEvent>)(e =>
            {
                DaqIo.Instance.TracingEnable = Settings.Default.TracingEnable;
                Checked = DaqIo.Instance.TracingEnable;

                if (Checked)
                {
                    BackColor = Color.Orange;
                    Text = $"Tracing Enabled";
                  //  _mainForm.TracingVisible = true;
                }
                else
                {
                    BackColor = SystemColors.Control;
                    Text = $"Tracing";
                  //  _mainForm.TracingVisible = false;
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
              //  _mainForm.TracingVisible = true;
            }
            else
            {
                BackColor = SystemColors.Control;
                Text = $"Tracing";
                //_mainForm.TracingVisible = false;
            }
        }
    }
}
