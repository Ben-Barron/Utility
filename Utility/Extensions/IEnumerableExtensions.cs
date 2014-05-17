using System;
using System.Collections.Generic;

namespace Utility.Extensions
{
    public static class IEnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action(item);
            }
        }
    }
}
