namespace Knv.Fan
{
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Controls;
    using System;

    public interface IMainForm
    {
        event EventHandler Shown;
        event FormClosedEventHandler FormClosed;
        event FormClosingEventHandler FormClosing;
        event EventHandler Disposed;

        string Text { get; set; }
        ToolStripItem[] MenuBar { set; }
        KnvRichTextBox RichTextBoxTrace { get; }
        ToolStripItem[] StatusBar { set; }
    }

    public partial class MainForm : Form , IMainForm
    {
        public ToolStripItem[] MenuBar
        {
            set { menuStrip1.Items.AddRange(value); }
        }

        public KnvRichTextBox RichTextBoxTrace
        {
            get
            {
                return knvRichTextBox1;
            }
        }

        public ToolStripItem[] StatusBar
        {
            set { statusStrip1.Items.AddRange(value); }
        }

        public MainForm()
        {
            InitializeComponent();
        }
    }
}
