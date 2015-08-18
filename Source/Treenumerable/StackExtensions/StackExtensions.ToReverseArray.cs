using System.Collections.Generic;

namespace Treenumerable
{
    internal static class StackExtensions
    {
        internal static T[] ToReverseArray<T>(this Stack<T> source)
        {
            T[] result = new T[source.Count];
            int count = source.Count - 1;
            foreach (T item in source)
            {
                result[count--] = item;
            }
            return result;
        }
    }
}
