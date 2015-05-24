using System;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Determines if a node has a parent.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node being checked for a parent.
        /// </param>
        /// <returns>
        /// Returns a <see cref="System.Boolean"/> indicating whether or not the node has a parent.
        /// </returns>
        public static bool HasParent<T>(this ITreeWalker<T> walker, T node)
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

            return walker.TryGetParent(node, out node);
        }
    }
}
