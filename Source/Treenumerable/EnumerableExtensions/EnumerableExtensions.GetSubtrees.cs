using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class EnumerableExtensions
    {
        public static IEnumerable<T> GetSubtrees<T>(
            this IEnumerable<T> nodes,
            ITreeWalker<T> walker,
            Func<T, bool> predicate,
            bool includeNodes)
        {
            return walker.GetSubtrees(nodes, predicate, includeNodes);
        }

        public static IEnumerable<T> GetSubtrees<T>(
            this IEnumerable<T> nodes,
            ITreeWalker<T> walker,
            Func<T, bool> predicate)
        {
            return walker.GetSubtrees(nodes, predicate, false);
        }
    }
}
