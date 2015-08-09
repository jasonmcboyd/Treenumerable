using System;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a node's parent node.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node whose parent is to be returned.
        /// </param>
        /// <returns>
        /// The node's parent.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        /// When the node does not have a parent.
        /// </exception>
        public static T GetParent<T>(this ITreeWalker<T> walker, T node)
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

            // Return the node's parent or throw an exception if the parent does not exist.
            T parent;
            if (walker.TryGetParent(node, out parent))
            {
                return parent;
            }
            else
            {
                throw new InvalidOperationException("The node does not have a parent.");
            }
        }
    }
}
