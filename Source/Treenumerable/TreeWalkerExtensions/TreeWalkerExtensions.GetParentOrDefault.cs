using System;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Returns a node's parent or a default node if no parent exists.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose parent is to be returned.
        /// </param>
        /// <returns>
        /// Returns a node's parent or a default node if no parent exists.
        /// </returns>
        public static T GetParentOrDefault<T>(this ITreeWalker<T> walker, T node)
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

            // Return the node's parent or a default node if the parent does not exist.
            if (walker.TryGetParent(node, out node))
            {
                return node;
            }
            else
            {
                return default(T);
            }
        }
    }
}
