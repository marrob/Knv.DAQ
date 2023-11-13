
namespace Knv.DAQ.Controls
{
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;
    using System.Windows.Forms.DataVisualization.Charting;

    public class KnvMovingChart: Chart
    {       
        public int VisibleSamples { get; set; } = 10;
        public int VerticalMaximum { get; set; } = 10;
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
            ChartAreas[0].AxisX.Maximum = VisibleSamples;

            //Values
            ChartAreas[0].AxisY.IntervalType = DateTimeIntervalType.Number;
            ChartAreas[0].AxisY.Minimum = 0;
            ChartAreas[0].AxisY.Maximum = VerticalMaximum;

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

            for (SampleIndex = 0; SampleIndex < 10; SampleIndex++)
            {
                Series[0].Points.AddXY(SampleIndex, 0);
                ChartAreas[0].AxisX.Minimum = Series[0].Points[0].XValue;
                ChartAreas[0].AxisX.Maximum = SampleIndex;
            }
        }

        public void AddSample(double y)
        {
            Series[0].Points.AddXY(SampleIndex, y);
            if (Series[0].Points.Count > VisibleSamples)
                Series[0].Points.RemoveAt(0);

            ChartAreas[0].AxisX.Minimum = Series[0].Points[0].XValue;
            ChartAreas[0].AxisX.Maximum = SampleIndex;
            SampleIndex++;
        }
    }
}
