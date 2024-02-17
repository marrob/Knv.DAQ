

namespace Knv.DAQ.View
{
    using System;
    using System.Windows.Forms;
    using Properties;

    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

            checkBoxAnalogInputPolling.Checked = Settings.Default.AnalogInputPolling;
            checkBoxAnalogInputPolling.CheckedChanged += (o, ey) =>  Settings.Default.AnalogInputPolling = checkBoxAnalogInputPolling.Checked; 

            checkBoxUpTimeCounterPolling.Checked = Settings.Default.UpTimeCounterPolling;
            checkBoxUpTimeCounterPolling.CheckedChanged += (o, ey) => Settings.Default.UpTimeCounterPolling = checkBoxUpTimeCounterPolling.Checked;

        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
    }
}
