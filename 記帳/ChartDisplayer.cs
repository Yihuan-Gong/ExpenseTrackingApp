using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using 記帳.ChartPloter;
using Backend;

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
            List<Backend.ExpenceDataType> types = new List<Backend.ExpenceDataType>();
            foreach (var type in chartUserInput.ExpenceDataTypes)
            {
                int temp = (int)type;
                types.Add((Backend.ExpenceDataType)temp);
            }

            int chartTypeInt = (int)FrontendBackendChartTypeMapping.GetBackendChartType(chartUserInput.ChartType);
            Backend.ChartType chartType = (Backend.ChartType)chartTypeInt;




            object chartData = chartDataBuilder.SetDateRange(chartUserInput.StartDate, chartUserInput.EndDate)
                                               .SetGroupByData(types)
                                               .SetChartType(chartType)
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
