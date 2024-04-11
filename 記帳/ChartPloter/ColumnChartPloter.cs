using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳.ChartPloter
{
    [DisplayName("ColumnPloter")]
    internal class ColumnChartPloter : AChartPloter
    {
        public override void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            List<Backend.ChartData<DateTime, int>> chartDataBackend = (List<Backend.ChartData<DateTime, int>>)chartData;

            ChartData<DateTime, int> columnChartData = new ChartData<DateTime, int>()
            {
                x = chartDataBackend[0].x,
                y = chartDataBackend[0].y,
                labels = chartDataBackend[0].labels,
                seriesName = chartDataBackend[0].seriesName
            };

            chart.Series.Clear();
            chart.Series.Add("Expence-Time");
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].Points.DataBindXY(
                columnChartData.x.Select(x => x.ToString("MMdd")).ToList(),
                columnChartData.y
            );
        }
    }
}
