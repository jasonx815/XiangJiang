using System;
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

        /// <summary>
        ///     复制数组
        ///     <para>
        ///         eg: CollectionAssert.AreEqual(new int[3] { 1, 2, 3 }, ArrayHelper.Copy(new int[5] { 1,
        ///         2, 3, 4, 5 }, 0, 3));
        ///     </para>
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="sourceArray">需要操作数组</param>
        /// <param name="startIndex">复制起始索引，从零开始</param>
        /// <param name="endIndex">复制结束索引</param>
        /// <returns>数组</returns>
        public static T[] Copy<T>(T[] sourceArray, int startIndex, int endIndex)
        {
            var len = endIndex - startIndex;
            var destination = new T[len];
            Array.Copy(sourceArray, startIndex, destination, 0, len);
            return destination;
        }
    }
}