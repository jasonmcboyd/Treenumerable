using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="nodes"></param>
        /// <param name="predicate"></param>
        /// <param name="includeNodes"></param>
        /// <returns></returns>
        public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, IEnumerable<T> nodes, Func<T, bool> predicate, bool includeNodes)
        {
            if (nodes == null)
            {
                yield break;
            }

            foreach (T node in nodes)
            {
                if (includeNodes && predicate.Invoke(node))
                {
                    yield return node;
                }
                else
                {
                    foreach (T descendant in walker.GetDescendants(walker.GetChildren(node), predicate, true))
                    {
                        yield return descendant;
                    }
                }
            }
        }

        public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, IEnumerable<T> nodes, Func<T, bool> predicate)
        {
            return walker.GetDescendants(nodes, predicate, false);
        }

        public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, T node, Func<T, bool> predicate, bool includeNode)
        {
            if (node == null)
            {
                return Enumerable.Empty<T>();
            }

            return walker.GetDescendants(Enumerable.Repeat(node, 1), predicate, includeNode);
        }

        public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, T node, Func<T, bool> predicate)
        {
            return walker.GetDescendants<T>(node, predicate, false);
        }
    }
}
