using System;
using System.Collections.Generic;

namespace Treenumerable
{
    internal static class StackExtensions
    {
        internal static TResult[] ToReverseArray<TSource, TResult>(
            this Stack<TSource> source,
            Func<TSource, TResult> selector)
        {
            TResult[] result = new TResult[source.Count];
            int count = source.Count - 1;
            foreach (TSource item in source)
            {
                result[count--] = selector(item);
            }
            return result;
        }
    }
}
