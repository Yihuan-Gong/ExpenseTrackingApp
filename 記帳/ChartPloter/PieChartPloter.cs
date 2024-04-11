using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳.ChartPloter
{
    [DisplayName("PiePloter")]
    internal class PieChartPlotssssser : AChartPloter
    {
        public override void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            List<Backend.ChartData<string, int>> chartDataBackend = (List<Backend.ChartData<string, int>>)chartData;

            ChartData<string, int> pieChartData = new ChartData<string, int>()
            {
                x = chartDataBackend[0].x,
                y = chartDataBackend[0].y,
                labels = chartDataBackend[0].labels,
                seriesName = chartDataBackend[0].seriesName
            };

            chart.Series.Clear();
            chart.Series.Add("Pie");
            chart.Series[0].ChartType = SeriesChartType.Pie;
            chart.Series[0].Points.DataBindXY(pieChartData.x, pieChartData.y);
            for (int i = 0; i < chart.Series[0].Points.Count; i++)
            {
                chart.Series[0].Points[i].Label = pieChartData.x[i];
                chart.Series[0].Points[i].LegendText = pieChartData.labels[i];
            }
        }
    }
}
