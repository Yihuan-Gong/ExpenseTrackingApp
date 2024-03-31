using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace 記帳
{
    internal static class FrontendBackendChartTypeMapping
    {
        private static Dictionary<SeriesChartType, ChartType> mapping =
            new Dictionary<SeriesChartType, ChartType>
            {
                { SeriesChartType.Pie, ChartType.Pie },
                { SeriesChartType.Column, ChartType.Column },
                { SeriesChartType.Line, ChartType.Line },
            };

        public static ChartType GetBackendChartType(SeriesChartType frontendChartType)
        {
            return mapping[frontendChartType];
        }
        
    }
}
