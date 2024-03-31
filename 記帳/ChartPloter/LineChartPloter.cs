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
    [DisplayName("LinePloter")]
    internal class LineChartPloter : AChartPloter
    {
        public override void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            var lineChartData = chartData as List<ChartData<DateTime, int>>;

            chart.Series.Clear();
            foreach (var item in lineChartData)
            {
                chart.Series.Add(item.seriesName);
                chart.Series[item.seriesName].ChartType = SeriesChartType.Line;
                chart.Series[item.seriesName].Points.DataBindXY(
                    item.x.Select(x => int.Parse(x.ToString("MM"))).ToList(),
                    item.y
                );
            }
        }
    }
}
