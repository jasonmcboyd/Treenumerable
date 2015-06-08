using System;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Determines if a node has children.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node being checked for children.
        /// </param>
        /// <returns>
        /// Returns a <see cref="System.Boolean"/> indicating whether or not the node has children.
        /// </returns>
        public static bool HasChildren<T>(this ITreeWalker<T> walker, T node)
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

            return walker.GetChildren(node).Any();
        }
    }
}
