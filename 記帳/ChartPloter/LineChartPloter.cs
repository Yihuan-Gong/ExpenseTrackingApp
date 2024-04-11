using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳.ChartPloter
{
    [DisplayName("LinePloter")]
    internal class LineChartPloter : AChartPloter
    {
        public override void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {



            List<Backend.ChartData<DateTime, int>> chartDataBackend = (List<Backend.ChartData<DateTime, int>>)chartData;




            List<ChartData<DateTime, int>> lineChartData = chartDataBackend.Select(x =>
                new ChartData<DateTime, int>
                {
                    x = x.x,
                    y = x.y,
                    labels = x.labels,
                    seriesName = x.seriesName
                }).ToList();

            chart.Series.Clear();
            foreach (var item in lineChartData) // lineChartData
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
