using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        
        public static IEnumerable<TResult> GetDescendantsOfType<TSource, TResult>(
            this ITreeWalker<TSource> walker,
            IEnumerable<TSource> nodes)
        {
            // Validate parameters.
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }

            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            foreach (object descendant in walker.GetDescendants(nodes, n => n is TResult))
            {
                yield return (TResult)descendant;
            }
        }
    }
}
