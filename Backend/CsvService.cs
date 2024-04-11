using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StreamLibarary;

namespace Backend
{
    public static class CsvService
    {
        public static List<RecordModel> GetRecords(DateTime date)
        {
            return CsvHelper.ReadCSV<RecordModel>(GetCsvPath(date));
        }

        public static List<RecordModel> GetRecords(DateTime startDate, DateTime endDate)
        {
            List<RecordModel> records = new List<RecordModel>();

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1.0))
            {
                records.AddRange(GetRecords(date));
            }

            return records;
        }

        public static void WriteRecordsToCsv(DateTime date, List<RecordModel> records)
        {
            string csvPath = GetCsvPath(date);
            CsvHelper.WriteCSV(csvPath, records, false);
        }

        private static string GetCsvPath(DateTime date)
        {
            string serverDir = ConfigurationManager.AppSettings["serverDir"];
            string dateStr = date.ToString("yyyy-MM-dd");
            string csvPath = $"{serverDir}\\Csv\\{dateStr}.csv";

            return csvPath;
        }


    }
}
