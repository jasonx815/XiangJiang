using System.Data;

namespace XiangJiang.Common
{
    /// <summary>
    ///     DataSet 帮助类
    /// </summary>
    /// 时间：2016-01-05 13:18
    /// 备注：
    public static class DataSetHelper
    {
        #region Methods

        /// <summary>
        ///     判断DataSet是否是NULL或者没有DataTable
        /// </summary>
        /// <param name="dataSet">DataSet</param>
        /// <returns>是否是NULL或者没有DataTable</returns>
        /// 时间：2016-01-05 13:19
        /// 备注：
        public static bool IsNullOrEmpty(this DataSet dataSet)
        {
            return dataSet == null || dataSet.Tables.Count == 0;
        }

        #endregion Methods
    }
}