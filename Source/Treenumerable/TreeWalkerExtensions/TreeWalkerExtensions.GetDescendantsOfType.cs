using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        public static IEnumerable<TResult> GetDescendantsOfType<TSource, TResult>(this ITreeWalker<TSource> walker, IEnumerable<TSource> nodes, bool includeNodes)
        {
            if (nodes == null)
            {
                yield break;
            }

            foreach (object node in nodes)
            {
                if (includeNodes && node is TResult)
                {
                    yield return (TResult)node;
                }
                else
                {
                    foreach (TResult descendant in walker.GetDescendantsOfType<TSource, TResult>(walker.GetChildren((TSource)node), true))
                    {
                        yield return descendant;
                    }
                }
            }
        }

        //public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, IEnumerable<T> nodes, Func<T, bool> predicate)
        //{
        //    return walker.GetDescendants(nodes, predicate, false);
        //}

        //public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, T node, Func<T, bool> predicate, bool includeNode)
        //{
        //    if (node == null)
        //    {
        //        return Enumerable.Empty<T>();
        //    }

        //    return walker.GetDescendants(Enumerable.Repeat(node, 1), predicate, includeNode);
        //}

        //public static IEnumerable<T> GetDescendants<T>(this ITreeWalker<T> walker, T node, Func<T, bool> predicate)
        //{
        //    return walker.GetDescendants<T>(node, predicate, false);
        //}
    }
}
