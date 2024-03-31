using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace 記帳.ChartDataFactory
{
    [DisplayName("PieData")]
    internal class PieChartData : AChartDataFactory
    {
        public PieChartData(DateTime start, DateTime end, ChartType chartType, IEnumerable<ExpenceDataType> groupByDataTypes)
            : base(start, end, chartType, groupByDataTypes) { }


        public override object GetChartData()
        {
            if (groupByDataTypes == null) return new ChartData<string, int>();

            var records = CsvService.GetRecords(start, end);

            var result = records
                .GroupBy(x => new
                {
                    Type = groupByDataTypes.Contains(ExpenceDataType.Type) ? x.Type : null,
                    Content = groupByDataTypes.Contains(ExpenceDataType.Content) ? x.Content : null,
                    PayMethod = groupByDataTypes.Contains(ExpenceDataType.PayMethod) ? x.PayMethod : null,
                    Property = groupByDataTypes.Contains(ExpenceDataType.Property) ? x.Property : null,
                })
                .Select(g => new
                {
                    Type = g.Key.Type,
                    Content = g.Key.Content,
                    PayMethod = g.Key.PayMethod,
                    Property = g.Key.Property,
                    Price = g.Sum(x => int.Parse(x.Price))
                });

            ChartData<string, int> pieChartData = new ChartData<string, int>();
            List<string> types = new List<string>();
            List<int> prices = new List<int>();
            List<string> labels = new List<string>();
            int totalPrice = result.Sum(x => x.Price);
            foreach (var item in result)
            {
                string type = $"{item.Type}  {item.Content}  {item.PayMethod}  {item.Property}";
                int price = item.Price;
                double pricePercentage = Math.Round((double)price / (double)totalPrice * 100.0, 0);
                string label = $"{type} {pricePercentage}%";

                types.Add(type);
                prices.Add(price);
                labels.Add(label);
            }

            return new List<ChartData<string, int>>
            {
                new ChartData<string, int>
                {
                    x = types,
                    y = prices,
                    labels = labels
                }
            };
        }
    }
}
