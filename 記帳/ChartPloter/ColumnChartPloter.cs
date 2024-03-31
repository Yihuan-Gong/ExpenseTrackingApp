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
    [DisplayName("ColumnPloter")]
    internal class ColumnChartPloter : AChartPloter
    {
        public override void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            var columnChartData = chartData as List<ChartData<DateTime, int>>;

            chart.Series.Clear();
            chart.Series.Add("Expence-Time");
            chart.Series[0].ChartType = SeriesChartType.Column;
            chart.Series[0].Points.DataBindXY(
                columnChartData[0].x.Select(x => x.ToString("MMdd")).ToList(),
                columnChartData[0].y
            );
        }
    }
}
