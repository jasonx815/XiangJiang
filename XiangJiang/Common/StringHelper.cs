using System;
using System.Text;

namespace XiangJiang.Common
{
    /// <summary>
    ///     字符串辅助类
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        ///     忽略大小写比较
        /// </summary>
        /// <param name="data">字符串</param>
        /// <param name="compareData">比较字符串</param>
        /// <returns>是否相等</returns>
        /// 时间：2016/8/29 9:14
        /// 备注：
        public static bool CompareIgnoreCase(this string data, string compareData)
        {
            return string.Equals(data, compareData, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     对字符串进行编码
        /// </summary>
        /// <param name="data">需要编码的字符串</param>
        /// <returns>编码后的字符串</returns>
        /// 时间:2016/10/16 13:02
        /// 备注:
        public static string Escape(this string data)
        {
            if (string.IsNullOrEmpty(data)) return data;
            var builder = new StringBuilder();
            foreach (var c in data)
                builder.Append(char.IsLetterOrDigit(c)
                               || c == '-' || c == '_' || c == '\\'
                               || c == '/' || c == '.'
                    ? c.ToString()
                    : Uri.HexEscape(c));

            return builder.ToString();
        }

        /// <summary>
        ///     对字符串进行解码
        /// </summary>
        /// <param name="data">需要解码的字符串</param>
        /// <returns>解码后的字符串</returns>
        /// 时间:2016/10/16 13:06
        /// 备注:
        public static string UnEscape(this string data)
        {
            if (string.IsNullOrEmpty(data)) return data;
            var builder = new StringBuilder();
            var count = data.Length;
            var index = 0;

            while (index != count)
                builder.Append(Uri.IsHexEncoding(data, index) ? Uri.HexUnescape(data, ref index) : data[index++]);

            return builder.ToString();
        }

        /// <summary>
        ///     获取全局唯一值
        /// </summary>
        /// <returns>全局唯一值</returns>
        public static string Unique()
        {
            return Guid.NewGuid().ToString().Replace("-", string.Empty);
        }
    }
}