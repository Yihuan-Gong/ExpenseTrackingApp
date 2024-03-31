using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using 記帳.ChartDataFactory;
using 記帳.ChartPloter;

namespace 記帳
{
    internal class ChartDisplayer
    {
        ChartDataBuilder chartDataBuilder;

        public ChartDisplayer()
        {
            chartDataBuilder = new ChartDataBuilder();
        }

        public void Display(ChartUserInput chartUserInput, System.Windows.Forms.DataVisualization.Charting.Chart chart)
        {
            object chartData = chartDataBuilder.SetDateRange(chartUserInput.StartDate, chartUserInput.EndDate)
                                               .SetGroupByData(chartUserInput.ExpenceDataTypes)
                                               .SetChartType(FrontendBackendChartTypeMapping.GetBackendChartType(chartUserInput.ChartType))
                                               .Build();

            AChartPloter chartPloter = GetChartPloter(chartUserInput.ChartType);
            chartPloter.Plot(chartData, chart);
        }

        private AChartPloter GetChartPloter(SeriesChartType chartType)
        {
            Type classesWithDisplayName =
                Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => type.GetCustomAttributes<DisplayNameAttribute>(false)
                                           .Any(attr => attr.DisplayName == $"{chartType}Ploter"))
                        .First();

            return (AChartPloter)Activator.CreateInstance(classesWithDisplayName);
        }
    }
}
