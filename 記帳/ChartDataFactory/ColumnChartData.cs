using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace 記帳.ChartDataFactory
{
    [DisplayName("Column")]
    internal class ColumnChartData : AChartDataFactory
    {
        public ColumnChartData(DateTime start, DateTime end, ChartType chartType, IEnumerable<ExpenceDataType> groupByDataTypes)
            : base(start, end, chartType, groupByDataTypes)
        {
        }

        public override object GetChartData()
        {
            List<DateTime> dates;
            List<int> prices;

            (dates, prices) = GetTimePriceCurveData(start, end, DateTimeAddMode.Day);

            return new List<ChartData<DateTime, int>>
            {
                new ChartData<DateTime, int>
                {
                    x = dates,
                    y = prices
                }
            };
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
