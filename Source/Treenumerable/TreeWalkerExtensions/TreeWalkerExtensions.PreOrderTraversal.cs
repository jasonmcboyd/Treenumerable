using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the preorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="includeNode">
        /// Indicates whether or not the <paramref name="node"/> is to be included in the resulting
        /// <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the nodes
        /// in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> PreOrderTraversal<T>(this ITreeWalker<T> walker, T node, bool includeNode)
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

            // If 'includeNode' is true then yield the root node.
            if (includeNode)
            {
                yield return node;
            }

            // Recursively yield each descendant using the preporder traversal method.
            foreach (T descendant in walker.GetChildren(node).SelectMany(x => walker.PreOrderTraversal(x, true)))
            {
                yield return descendant;
            }
        }

        /// <summary>
        /// Enumerates a tree using the preorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the nodes
        /// in the tree ordered based on a preord traversal.
        /// </returns>
        public static IEnumerable<T> PreOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PreOrderTraversal(node, false);
        }
    }
}
