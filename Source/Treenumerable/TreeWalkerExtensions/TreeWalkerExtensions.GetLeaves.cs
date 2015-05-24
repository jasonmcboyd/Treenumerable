using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a node's leaves, i.e. all descendants of that node that do not have children.  If
        /// the node has no children then the node, itself, is returned.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose leaves are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the node's
        /// leaves.
        /// </returns>
        public static IEnumerable<T> GetLeaves<T>(this ITreeWalker<T> walker, T node)
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

            // If a node has children then return the leaves of each child.
            // Otherwise, return the node.
            if (walker.HasChildren(node))
            {
                return
                    walker
                    .GetChildren(node)
                    .SelectMany(x => walker.GetLeaves(x));
            }
            else
            {
                return new T[] { node };
            }
        }
    }
}
