using System;
using System.Linq;

namespace XiangJiang.Common
{
    public static class DateTimeHelper
    {
        public static bool IsWeekend(this DateTime dateTime)
        {
            DayOfWeek[] weeks = {DayOfWeek.Saturday, DayOfWeek.Sunday};
            return weeks.Contains(dateTime.DayOfWeek);
        }

        public static bool IsWeekday(this DateTime dateTime)
        {
            DayOfWeek[] weeks =
                {DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday};
            return weeks.Contains(dateTime.DayOfWeek);
        }

        public static string ToUniqueString(this DateTime dateTime, bool milSec = false)
        {
            var seconds = dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
            var value = $"{dateTime:yy}{dateTime.DayOfYear}{seconds}";
            return milSec ? string.Concat(value, dateTime.ToString("fff")) : value;
        }
    }
}