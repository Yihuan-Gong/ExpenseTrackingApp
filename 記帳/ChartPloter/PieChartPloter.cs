using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using 記帳.ChartDataFactory;

namespace 記帳.ChartPloter
{
    [DisplayName("PiePloter")]
    internal class PieChartPlotssssser : AChartPloter
    {
        public override void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            var pieChartData = chartData as List<ChartData<string, int>>;

            chart.Series.Clear();
            chart.Series.Add("Pie");
            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0].Points.DataBindXY(pieChartData[0].x, pieChartData[0].y);
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                chart.Series[0].Points[i].Label = pieChartData[0].x[i];
                chart.Series[0].Points[i].LegendText = pieChartData[0].labels[i];
            }
        }
    }
}
