using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static class EnumerableOfVirtualTreeExtensions
    {
        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees, 
            Func<T, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .SelectDescendants(virtualTree.Root, predicate)
                    .Select(x => virtualTree.CreateFromSelf(x)));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees, 
            Func<T, int, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .SelectDescendants(virtualTree.Root, predicate)
                    .Select(x => virtualTree.CreateFromSelf(x)));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees, 
            T key)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .SelectDescendants(virtualTree.Root, key)
                    .Select(x => virtualTree.CreateFromSelf(x)));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees, 
            T key, 
            IEqualityComparer<T> comparer)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .SelectDescendants(virtualTree.Root, key, comparer)
                    .Select(x => virtualTree.CreateFromSelf(x)));
        }

        public static IEnumerable<VirtualTree<T>> SelectChildren<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            Func<T, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(x => x.SelectChildren(predicate));
        }

        public static IEnumerable<VirtualTree<T>> SelectChildren<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            T key)
        {
            return
                virtualTrees
                .SelectMany(x => x.SelectChildren(key));
        }

        public static IEnumerable<VirtualTree<T>> SelectChildren<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            T key,
            IEqualityComparer<T> comparer)
        {
            return
                virtualTrees
                .SelectMany(x => x.SelectChildren(key, comparer));
        }

        public static IEnumerable<VirtualTree<T>> GetChildAt<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            int index)
        {
            return
                virtualTrees
                .Select(x => x.GetChildAt(index));
        }

        public static IEnumerable<VirtualTree<T>> GetChildAtOrDefault<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            int index)
        {
            return
                virtualTrees
                .Select(x => x.GetChildAtOrDefault(index));
        }

        public static IEnumerable<T> Unwrap<T>(this IEnumerable<VirtualTree<T>> virtualTrees)
        {
            foreach (VirtualTree<T> tree in virtualTrees)
            {
                yield return tree.Root;
            }
        }
    }
}
