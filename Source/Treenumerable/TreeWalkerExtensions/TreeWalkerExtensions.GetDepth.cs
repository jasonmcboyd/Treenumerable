using System;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the depth of the node.  The depth is measured by the number of edges between
        /// <paramref name="node"/> and the root of the tree.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose depth is to be returned.
        /// </param>
        /// <returns>
        /// The number of edges between <paramref name="node"/> and the root of the tree.
        /// </returns>
        public static int GetDepth<T>(this ITreeWalker<T> walker, T node)
        {
            // Validate parameters.
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }

            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            // Return the depth of 'node' by counting the nodes ancestors.
            return walker.GetAncestors(node).Count();
        }
    }
}
