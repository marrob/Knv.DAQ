

namespace Knv.DAQ.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class KnvAnalogInputControl : UserControl
    {
        [Category("KNV")]
        public string Title 
        { 
            get { return textBoxTitle.Text; }
            set { textBoxTitle.Text = value; }
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
        [DefaultValue(10)]
        public int Samples 
        {
            get 
            {
                return knvMovingChart1.Samples; 
            }
            set 
            { 
                knvMovingChart1.Samples = value;
                numericUpDownSamples.Value = value;
            }
        }
        

        public KnvAnalogInputControl()
        {
            InitializeComponent();
        }

        public void AddSample(double valueOfSample)
        {
            var value = valueOfSample * Multiplier + Offset ;
            knvMovingChart1.AddSample(value);
            textBoxCustomValue.Text = $"{value:N2}{Unit}";
            textBoxRawValue.Text = $"{valueOfSample:N2}V";
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

        private void numericUpDownSamples_ValueChanged(object sender, EventArgs e)
        {
            Samples = (int)numericUpDownSamples.Value;
        }
    }
}
