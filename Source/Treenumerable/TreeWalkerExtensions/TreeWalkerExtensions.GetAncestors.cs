using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a nodes ancestors, starting with its parent node and ending with the root node.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose ancestors are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable<T>"/> that contains all the nodes
        /// ancestors, up to and including the root.
        /// </returns>
        public static IEnumerable<T> GetAncestors<T>(this ITreeWalker<T> walker, T node)
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

            // Get and return each parent node iteratively.
            ParentNode<T> parentNode = walker.GetParentNode(node);
            while (parentNode.HasValue)
            {
                yield return parentNode.Value;
                parentNode = walker.GetParentNode(parentNode.Value);
            }
        }
    }
}
