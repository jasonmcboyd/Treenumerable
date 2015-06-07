using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static class EnumerableOfVirtualTreeExtensions
    {
        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(this IEnumerable<VirtualTree<T>> virtualTrees, Func<T, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .SelectDescendants(virtualTree.Root, predicate)
                    .Select(x => new VirtualTree<T>(virtualTree.TreeWalker, x)));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(this IEnumerable<VirtualTree<T>> virtualTrees, Func<T, int, bool> predicate)
        {
            return
                virtualTrees
                .SelectMany(virtualTree =>
                    virtualTree
                    .TreeWalker
                    .SelectDescendants(virtualTree.Root, predicate)
                    .Select(x => new VirtualTree<T>(virtualTree.TreeWalker, x)));
        }
    }
}
