using System;
using System.Collections.Generic;
using System.Text;

namespace Sharedkernel.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Merge<T>(this IEnumerable<IEnumerable<T>> lists)
        {
            foreach (var childList in lists)
                foreach (var item in childList)
                    yield return item;
        }

        public static IEnumerable<T> Merge<T>(this IEnumerable<T> list, params IEnumerable<T>[] anotherList)
        {
            foreach (var item in list)
                yield return item;
            foreach (var item in anotherList.Merge())
                yield return item;
        }
    }
}
