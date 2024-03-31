using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 記帳
{
    internal static class DateTimeExtension
    {
        public static DateTime Add(this DateTime dateTime, DateTimeAddMode dateTimeAddMode)
        {
            switch (dateTimeAddMode)
            {
                case DateTimeAddMode.Day:
                    return dateTime.AddDays(1.0);
                case DateTimeAddMode.Week:
                    return dateTime.AddDays(7.0);
                case DateTimeAddMode.Month:
                    return dateTime.AddMonths(1);
            }

            return dateTime;
        }
    }
}
