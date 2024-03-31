using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳.ChartPloter
{
    internal abstract class AChartPloter
    {
        public abstract void Plot(object chartData, System.Windows.Forms.DataVisualization.Charting.Chart chart);
    }
}
