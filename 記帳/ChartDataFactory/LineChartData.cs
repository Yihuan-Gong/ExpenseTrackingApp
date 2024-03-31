using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace 記帳.ChartDataFactory
{
    [DisplayName("Line")]
    internal class LineChartData : AChartDataFactory
    {
        public LineChartData(DateTime start, DateTime end, ChartType chartType, IEnumerable<ExpenceDataType> groupByDataTypes)
            : base(start, end, chartType, groupByDataTypes)
        {
        }

        public override object GetChartData()
        {
            List<ChartData<DateTime, int>> lineChartData = new List<ChartData<DateTime, int>>();

            var startYear = start.Year;
            var endYear = end.Year;

            for (int year = startYear; year <= endYear; year++)
            {
                DateTime start = new DateTime(year, 1, 1);
                DateTime end = new DateTime(year, 12, 31);
                List<DateTime> dates;
                List<int> prices;

                (dates, prices) = GetTimePriceCurveData(start, end, DateTimeAddMode.Month);
                lineChartData.Add(new ChartData<DateTime, int> { x = dates, y = prices, seriesName = year.ToString() });
            }

            return lineChartData;
        }

        private (List<DateTime>, List<int>) GetTimePriceCurveData(DateTime start, DateTime end, DateTimeAddMode addMode)
        {
            var dates = new List<DateTime>();
            var prices = new List<int>();

            for (DateTime date = start; date <= end; date = date.Add(addMode))
            {
                dates.Add(date);
                prices.Add(
                    CsvService.GetRecords(date, date.Add(addMode)).Sum(x => int.Parse(x.Price)));
            }

            return (dates, prices);
        }
    }
}
