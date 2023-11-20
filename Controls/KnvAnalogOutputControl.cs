using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Knv.DAQ.Controls
{
    public partial class KnvAnalogOutputControl : UserControl
    {

        public event EventHandler<double>ValueChanged;

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
        public double Offset
        {
            get { return _offset; }
            set
            {
                if (value != _offset)
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
        public double Value 
        {
            get
            {
                return trackBar1.Value / 10;
            }
            set
            {
                trackBar1.Value = (int)(value * 10);
                double ao = trackBar1.Value / 10.0;
                labelCustomValue.Text = $"{ao * Multiplier + Offset}{Unit}";
                textBoxRaw.Text = $"{ao:N2}V";
            }
        }

        void MultiplierOrOffsetChanged()
        {
            double ao = trackBar1.Value / 10.0;
            labelCustomValue.Text = $"{ao * Multiplier + Offset}{Unit}";
            textBoxRaw.Text = $"{ao:N2}V";
        }

        public KnvAnalogOutputControl()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            double ao = trackBar1.Value / 10.0;
            labelCustomValue.Text = $"{ao * Multiplier + Offset}{Unit}";
            textBoxRaw.Text = $"{ao:N2}V";
            ValueChanged?.Invoke(this, ao);
        }

        private void textBoxMulti_TextChanged(object sender, EventArgs e)
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
    }
}
