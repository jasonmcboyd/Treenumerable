using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        public static VirtualTreeEnumerable<T> GetChildren<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            Func<T, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(x => x.GetChildren(predicate))
                .AsVirtualTreeEnumerable();
        }

        public static VirtualTreeEnumerable<T> GetChildren<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            T key)
        {
            return
                virtualTrees
                .SelectMany(x => x.GetChildren(key, x.Comparer))
                .AsVirtualTreeEnumerable();
        }

        public static VirtualTreeEnumerable<T> GetChildren<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            T key,
            IEqualityComparer<T> comparer)
        {
            return
                virtualTrees
                .SelectMany(x => x.GetChildren(key, comparer))
                .AsVirtualTreeEnumerable();
        }
    }
}
