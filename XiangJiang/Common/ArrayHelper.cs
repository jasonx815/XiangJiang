using System.Linq;

namespace XiangJiang.Common
{
    /// <summary>
    /// Array 辅助类
    /// </summary>
    public static class ArrayHelper
    {
        /// <summary>
        ///     字符串数值忽略大小写包含判断
        /// </summary>
        /// <param name="sourceArray">需要操作的数组</param>
        /// <param name="compareStringItem">包含判断的字符串</param>
        /// <returns>是否包含在内</returns>
        public static bool ContainIgnoreCase(this string[] sourceArray, string compareStringItem)
        {
            return sourceArray.Any(item => item.CompareIgnoreCase(compareStringItem));
        }
    }
}