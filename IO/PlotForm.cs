

namespace Knv.DAQ.IO
{
    using System;
    using System.Windows.Forms;
    public partial class PlotForm : Form
    {
        public event EventHandler AcqDownload;
        public PlotForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AcqDownload?.Invoke(this, EventArgs.Empty);
        }
    }
}
