
namespace Knv.DAQ.Controls
{
    using System.ComponentModel;
    using System.Windows.Forms.DataVisualization.Charting;

    public class KnvMovingChart : Chart
    {

        [Category("KNV")]
        [DefaultValue(10)]
        int _samples;     
        public int Samples
        {
            get { return _samples; }
            set
            {
                if (_samples != value)
                {
                    _samples = value;
                    ChangeSample();
                }
            }
        }

        [Category("KNV")]
        [DefaultValue(10)]
        public double VerticalMaximum { 
            get 
            { 
                return ChartAreas[0].AxisY.Maximum; 
            }
            set
            {
                ChartAreas[0].AxisY.Maximum = value;
            } 
        }
        public int SampleIndex { get; set; } = 0;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new ChartAreaCollection ChartAreas => base.ChartAreas;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new SeriesCollection Series => base.Series;


        public KnvMovingChart()
        {

            ChartAreas.Clear();

            var area = new ChartArea();
            area.Name = "MovingChartArea";
            ChartAreas.Add(area);

            //Timea
            ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Number;
            ChartAreas[0].AxisX.Minimum = 0;
            ChartAreas[0].AxisX.Maximum = _samples;

            //Values
            ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Number;
            ChartAreas[0].AxisY.Minimum = 0;
            //ChartAreas[0].AxisY.Maximum = VerticalMaximum;
            VerticalMaximum = 10;

            Series.Clear();
            var seriesItem = new Series();
            seriesItem.Name = "Something";

            Series.Add(seriesItem);
            Series[0].ChartType = SeriesChartType.Line;
            Series[0].Color = System.Drawing.Color.Red ;
        }

        public void Reset()
        {
           Series[0].Points.Clear();

            for (SampleIndex = 0; SampleIndex < Samples; SampleIndex++)
            {
                Series[0].Points.AddXY(SampleIndex, 0);
                ChartAreas[0].AxisX.Minimum = Series[0].Points[0].XValue;
                ChartAreas[0].AxisX.Maximum = SampleIndex;
            }
        }

        public void AddSample(double y)
        {
            Series[0].Points.AddXY(SampleIndex, y);
            if (Series[0].Points.Count > Samples)
                Series[0].Points.RemoveAt(0);

            ChartAreas[0].AxisX.Minimum = Series[0].Points[0].XValue;
            ChartAreas[0].AxisX.Maximum = SampleIndex;
            SampleIndex++;
        }

        void ChangeSample()
        {
            ChartAreas[0].AxisX.Maximum = _samples;
        }
    }
}
