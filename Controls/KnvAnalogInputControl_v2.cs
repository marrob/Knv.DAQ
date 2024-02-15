

namespace Knv.DAQ.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public partial class KnvAnalogInputControl_v2 : UserControl
    {
        [Category("KNV")]

        string _title;
        public string Title 
        { 
            get 
            {
                return _title;
            }
            set 
            {
                _title = value;
                labelTitle.Text = value; 
                textBoxTitle.Text = value;
            }
        }

        [Category("KNV")]
        public string PhyName
        {
            get { return labelPhyName.Text; }
            set { labelPhyName.Text = value; }
        }

        Color _color = SystemColors.Control;
        [Category("KNV")]
        public Color Channel
        {
            get { return _color; }
            set
            {
                _color = value;
                labelPhyName.BackColor = value;
                labelTitle.BackColor = value;
                labelSettings.BackColor = value;
            }
        }

        double _multi = double.NaN;
        [Category("KNV")]
        public double Multiplier
        { 
            get { return _multi; }
            set 
            {
                if (_multi != value)
                {
                    _multi = value;
                    textBoxMulti.Text = value.ToString();
                    MultiplierOrOffsetChanged();
                }
            }
        }
        double _offset = double.NaN;

        [Category("KNV")]
        public double Offset {
            get { return _offset; }
            set
            { 
                if(value != _offset) 
                {
                    _offset = value;
                    textBoxOffset.Text = value.ToString();
                    MultiplierOrOffsetChanged();
                }
            }
        }

        [Category("KNV")]
        public string Unit 
        { 
            get { return textBoxUnit.Text; }
            set { textBoxUnit.Text = value; }
        }

        [Category("KNV")]
        public double MaxRawValue { get; set; } = 10;

        [Category("KNV")]
        public string SelctedTab
        {
            get { return tabControl1.SelectedTab.Name; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (tabControl1.TabPages.Cast<TabPage>().Select(x => x.Name).Contains(value))
                        tabControl1.SelectTab(value);
                }
            }
        }



        public KnvAnalogInputControl_v2()
        {
            InitializeComponent();

            knvMovingChart1.Samples = 10;
        }

        public void AddSample(double valueOfSample)
        {
            var value = valueOfSample * Multiplier + Offset ;
            knvMovingChart1.AddSample(value);
            textBoxCustomValue.Text = $"{value:N2}{Unit}";
            textBoxRawValue.Text = $"{valueOfSample:N2}V";
            labelSettings.Text = $"{Offset}..{10 * Multiplier + Offset}{Unit}";
        }

        void MultiplierOrOffsetChanged()
        {
            knvMovingChart1.VerticalMaximum = MaxRawValue * Multiplier + Offset;
        }

        private void textBoxMultipler_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxMulti.Text, out double value))
            {
                textBoxMulti.BackColor = Color.White;
                Multiplier = value;
            }
            else 
            {
                textBoxMulti.BackColor = Color.Red;
            }
        }

        private void textBoxOffset_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBoxOffset.Text, out double value))
            {
                textBoxOffset.BackColor = Color.White;
                Offset = value;
            }
            else
            {
                textBoxOffset.BackColor = Color.Red;
            }
        }

        private void KnvAnalogInputControl_v2_Load(object sender, EventArgs e)
        {

        }
    }
}
