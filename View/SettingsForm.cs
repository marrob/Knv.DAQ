

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



        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            DialogResult= DialogResult.OK;
        }
    }
}
