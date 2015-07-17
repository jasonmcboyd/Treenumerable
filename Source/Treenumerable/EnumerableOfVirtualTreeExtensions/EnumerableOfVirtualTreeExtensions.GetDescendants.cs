using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        public static VirtualTreeEnumerable<T> GetDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            Func<T, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .GetDescendants(virtualTree.Root, predicate)
                    .ToVirtualTrees(virtualTree))
                .AsVirtualTreeEnumerable();
        }

        public static VirtualTreeEnumerable<T> GetDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            Func<T, int, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .GetDescendants(virtualTree.Root, predicate)
                    .ToVirtualTrees(virtualTree))
                .AsVirtualTreeEnumerable();
        }

        public static VirtualTreeEnumerable<T> GetDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            T key)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .GetDescendants(virtualTree.Root, key, virtualTree.Comparer)
                    .ToVirtualTrees(virtualTree))
                .AsVirtualTreeEnumerable();
        }

        public static VirtualTreeEnumerable<T> GetDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            T key,
            IEqualityComparer<T> comparer)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .GetDescendants(virtualTree.Root, key, comparer)
                    .ToVirtualTrees(virtualTree))
                .AsVirtualTreeEnumerable();
        }
    }
}
