using System;
using System.Collections.Generic;

namespace MyLinq
{
    static class MeuEnumerable
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> items, Func<T, bool> test)
        {
            foreach (var item in items)
            {
                if (test(item))
                    yield return item;
            }
        }

        public static IEnumerable<TResult> Select<T, TResult>(this IEnumerable<T> items,
            Func<T, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }
    }
}
