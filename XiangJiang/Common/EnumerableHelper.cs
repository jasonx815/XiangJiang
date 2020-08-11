using System.Collections;

namespace XiangJiang.Common
{
    /// <summary>
    ///     IEnumerable 辅助类
    /// </summary>
    public static class EnumerableHelper
    {
        /// <summary>
        ///     集合是否是空或者NULL
        /// </summary>
        /// <param name="source">IEnumerable</param>
        /// <returns>否是空或者NULL</returns>
        public static bool IsNullOrEmpty(this IEnumerable source)
        {
            return source?.GetEnumerator().MoveNext() == false;
        }
    }
}