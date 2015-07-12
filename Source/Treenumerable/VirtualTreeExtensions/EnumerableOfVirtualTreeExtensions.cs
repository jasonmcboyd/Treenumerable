using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static class EnumerableOfVirtualTreeExtensions
    {
        /// <summary>
        /// Takes an <see cref="IEnumerable&lt;VirtualTree&lt;T&gt;&gt;"/> and returns each 
        /// <see cref="VirtualTree&lt;T&gt;"/>'s child at the specified index.  If the index is
        /// greater than the number of children then no child is returned for that 
        /// <see cref="VirtualTree&lt;T&gt;"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="virtualTrees">
        /// The <see cref="VirtualTree&lt;T&gt;"/>'s that are to have their child returned.
        /// </param>
        /// <param name="index">
        /// The index of the child to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable&lt;VirtualTree&lt;T&gt;&gt;"/> representing the selected
        /// child from each <see cref="VirtualTree&lt;T&gt;"/>.
        /// </returns>
        public static IEnumerable<VirtualTree<T>> GetChildAt<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (virtualTrees == null)
            {
                throw new ArgumentNullException("virtualTrees");
            }

            foreach (VirtualTree<T> tree in virtualTrees)
            {
                IList<T> list = tree.TreeWalker.GetChildren(tree.Root) as IList<T>;
                if (list != null)
                {
                    if (index < list.Count)
                    {
                        yield return tree.CreateFromSelf(list[index]);
                    }
                }
                else
                {
                    int count = 0;
                    foreach (T node in tree.TreeWalker.GetChildren(tree.Root))
                    {
                        if (count == index)
                        {
                            yield return tree.CreateFromSelf(node);
                            break;
                        }
                        count++;
                    }
                }
            }
        }

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
