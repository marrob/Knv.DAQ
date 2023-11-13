namespace Knv.DAQ.StatusBar
{
    using System.Windows.Forms;

    class EmptyStatus : ToolStripStatusLabel
    {
        public EmptyStatus()
        {
            Spring = true;
        }
    }
}
