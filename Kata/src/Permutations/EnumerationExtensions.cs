using System;
using System.Collections.Generic;
using System.Linq;

namespace Permutations
{
    public static class EnumerationExtensions
    {
        public static IEnumerable<IEnumerable<T>> TransfigureLast<T>(this IEnumerable<T> source)
        {
            var list = source.ToArray();
            for (int i = 0; i < list.Length; i++)
            {
                yield return list.TakeLast(i)
                    .Concat(list.SkipLast(i));
            }
        }

        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<IEnumerable<T>> source,
            Func<IEnumerable<T>, TResult> action)
        {
            foreach (var arraignment in source)
            {
                yield return action.Invoke(arraignment);
            }
        }
    }
}