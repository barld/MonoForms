using System;
using System.Collections.Generic;

namespace MonoForms.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T> f)
        {
            foreach (T item in collection)
                f(item);
        }
    }
}