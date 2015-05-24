using System;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the height of the node.  The height is measured by the number of edges between
        /// <paramref name="node"/> and the deepest leaf.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose height is to be returned.
        /// </param>
        /// <returns>
        /// The number of edges between <paramref name="node"/> and the deepest leaf.
        /// </returns>
        public static int GetHeight<T>(this ITreeWalker<T> walker, T node)
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

            // If a node has children then return max height of the children plus 1.
            // Otherwise, return 0.
            if (walker.HasChildren(node))
            {
                return 1 + walker.GetChildren(node).Select(x => walker.GetHeight(x)).Max();
            }
            else
            {
                return 0;
            }
        }
    }
}
