using System;

namespace XiangJiang.Common
{
    public static class DateTimeOffsetHelper
    {
        public static bool IsNullOrEmpty(this DateTimeOffset dateTimeOffset)
        {
            return dateTimeOffset == DateTimeOffset.MinValue || dateTimeOffset == DateTimeOffset.MaxValue;
        }

        public static bool IsNullOrEmpty(this DateTimeOffset? dateTimeOffset)
        {
            return dateTimeOffset == null || IsNullOrEmpty(dateTimeOffset.Value);
        }
    }
}