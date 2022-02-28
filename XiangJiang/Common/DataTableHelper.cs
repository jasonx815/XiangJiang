using System;
using System.Data;
using System.Linq;
using XiangJiang.Core;

namespace XiangJiang.Common
{
    public static class DataTableHelper
    {
        public static decimal CastDecimalThenSum(this DataTable table, string columnName)
        {
            CheckTableAndColumnName(table, columnName);
            return table.IsEmpty()
                ? default
                : table.AsEnumerable().Sum(x => x[columnName] is DBNull ? 0 : GetValue<decimal>(x[columnName]));
        }

        private static void CheckTableAndColumnName(DataTable table, string columnName)
        {
            Checker.Begin().NotNull(table, nameof(table)).NotNullOrEmpty(columnName, nameof(columnName));
        }

        public static decimal CastIntThenSum(this DataTable table, string columnName)
        {
            CheckTableAndColumnName(table, columnName);
            return table.IsEmpty() ? default(int) : table.AsEnumerable().Sum(x => x[columnName] is DBNull ? 0 : GetValue<int>(x[columnName]));
        }

        public static float CastFloatThenSum(this DataTable table, string columnName)
        {
            CheckTableAndColumnName(table, columnName);
            return table.IsEmpty() ? default : table.AsEnumerable().Sum(x => x[columnName] is DBNull ? 0 : GetValue<float>(x[columnName]));
        }

        public static bool ContainColumn(this DataTable table, string columnName)
        {
            CheckTableAndColumnName(table, columnName);
            var columns = table.Columns;
            return columns.Contains(columnName);
        }

        public static bool IsEmpty(this DataTable table)
        {
            return table == null || table.Rows.Count == 0 || table.Columns.Count == 0;
        }

        private static T GetValue<T>(object value)
        {
            return (T) Convert.ChangeType(value, typeof(T));
        }
    }
}