using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XiangJiang.Core;

namespace XiangJiang.Common
{
    public static class CollectionHelper
    {
        public static bool IsEmpty<T>(this IEnumerable<T> collection)
        {
            collection = collection as IList<T> ?? collection.ToList();
            return !collection.Any();
        }

        public static string ExpandAndToString<T>(this IEnumerable<T> collection, string separator = ",")
        {
            return collection.ExpandAndToString(t => t.ToString(), separator);
        }

        public static string ExpandAndToString<T>(this IEnumerable<T> collection, Func<T, string> expandFactory,
            string separator = ",")
        {
            Checker.Begin().NotNull(collection, nameof(collection));
            collection = collection as IList<T> ?? collection.ToList();
            if (!collection.Any()) return string.Empty;
            var builder = new StringBuilder();
            var i = 0;
            var count = collection.Count();
            foreach (var item in collection)
            {
                if (i == count - 1)
                    builder.Append(expandFactory(item));
                else
                    builder.Append(expandFactory(item) + separator);
                i++;
            }

            return builder.ToString();
        }
    }
}