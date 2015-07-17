using System.Collections.Generic;

namespace Treenumerable
{
    internal static class EnumerableExtensions
    {
        internal static IEnumerable<VirtualTree<T>> ToVirtualTrees<T>(
            this IEnumerable<T> source,
            VirtualTree<T> virtualTree)
        {
            foreach (T node in source)
            {
                yield return virtualTree.ShallowCopy(node);
            }
        }

        internal static IEnumerable<VirtualTree<T>> ToVirtualTrees<T>(
            this IEnumerable<T> source,
            ITreeWalker<T> walker)
        {
            
            foreach (T root in source)
            {
                yield return new VirtualTree<T>(walker, root);
            }
        }

        internal static IEnumerable<VirtualTree<T>> ToVirtualTrees<T>(
            this IEnumerable<T> source,
            ITreeWalker<T> walker,
            IEqualityComparer<T> comparer)
        {
            foreach (T root in source)
            {
                yield return new VirtualTree<T>(walker, root, comparer);
            }
        }
    }
}
