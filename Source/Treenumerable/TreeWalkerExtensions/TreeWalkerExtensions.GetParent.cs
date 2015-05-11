using System;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Returns a nodes parent.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose parent is to be returned.
        /// </param>
        /// <returns>
        /// Returns a nodes parent.  This differs from <see cref="ITreeWalker<T>.GetParent"/> in
        /// that it returns the parent directly rather than a <see cref="ParentNode<T>"/>.
        /// </returns>
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

            // Return the node's parent.
            ParentNode<T> parentNode = walker.GetParentNode(node);
            return parentNode.HasValue ? parentNode.Value : default(T);
        }
    }
}
