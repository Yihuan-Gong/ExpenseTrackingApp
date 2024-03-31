using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using 記帳.ChartDataFactory;

namespace 記帳
{
    internal class ChartBuilder
    {
        private DateTime startDate;
        private DateTime endDate;
        private ChartType chartType;
        private IEnumerable<ExpenceDataType> expenceDataTypes;


        public ChartBuilder SetDateRange(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                Console.WriteLine("開始時間必須早於結束時間！");
                return null;
            }

            this.startDate = startDate;
            this.endDate = endDate;
            return this;
        }


        public ChartBuilder SetGroupByData(IEnumerable<ExpenceDataType> expenceDataTypes)
        {
            this.expenceDataTypes = expenceDataTypes;
            return this;
        }


        public ChartBuilder SetChartType(ChartType chartType)
        {
            this.chartType = chartType;
            return this;
        }



        public List<ChartData<Tx, Ty>> Build<Tx, Ty>()
        {

            // 找到所有類型，並過濾出具有指定DisplayName的類別
            Type classesWithDisplayName = 
                Assembly.GetExecutingAssembly().GetTypes()
                        .Where(type => type.GetCustomAttributes<DisplayNameAttribute>(false)
                                           .Any(attr => attr.DisplayName == $"{chartType}"))
                        .First();

            var factory = (AChartDataFactory)Activator.CreateInstance(classesWithDisplayName, startDate, endDate, chartType, expenceDataTypes);

            return (List<ChartData<Tx, Ty>>)factory.GetChartData();


            // 問題
            // 1. 使用者在使用Build的時候必須預先知道他會回傳的type，才能拿到資料
        }

    }
}
