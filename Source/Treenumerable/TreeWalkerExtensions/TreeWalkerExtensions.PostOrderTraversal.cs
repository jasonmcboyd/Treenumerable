using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
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
        /// in the tree ordered based on a postorder traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node, bool includeNode)
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

            // Loop over each child, calling PostOrderTraversal, and yield the results.
            foreach (T descendant in walker.GetChildren(node).SelectMany(x => walker.PostOrderTraversal(x, true)))
            {
                yield return descendant;
            }

            // If 'includeNode' is true then yield 'node'.
            if (includeNode)
            {
                yield return node;
            }
        }

        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the nodes
        /// in the tree ordered based on a postorder traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PostOrderTraversal(node, false);
        }
    }
}
