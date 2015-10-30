using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a node and the node's siblings, i.e. all nodes that share the same parent.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node whose siblings are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains the
        /// siblings.
        /// </returns>
        public static IEnumerable<T> GetSiblingsAndSelf<T>(this ITreeWalker<T> walker, T node)
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

            // Get the node's parent.
            T parent;
            if (walker.TryGetParent(node, out parent))
            {
                // Return all of the parent's children with the exception of the original node.
                return
                    walker
                    .GetChildren(parent);
            }
            else
            {
                // If the node does not have a parent then return the node.
                return new T[] { node };
            }
        }
    }
}
