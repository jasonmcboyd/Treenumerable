using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Returns all nodes at a depth relative to the specified node.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node relative to which the level is returned.
        /// </param>
        /// <param name="depth">
        /// The depth of the level to be returned relateive to <paramref name="node"/>.  This must
        /// be a nonnegative number.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the nodes
        /// nodes at a depth relative to the specified node.  A depth of 0 will return the node 
        /// itself, 1 all children of the node, etc...
        /// </returns>
        public static IEnumerable<T> GetLevel<T>(this ITreeWalker<T> walker, T node, int depth)
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

            if (depth < 0)
            {
                throw new ArgumentException("Depth must be nonnegative.", "depth");
            }

            // If 'depth' is zero then return the node.
            // Otherwise, return all levels of 'depth' - 1 of the child nodes.
            if (depth == 0)
            {
                return Enumerable.Repeat(node, 1);
            }
            else
            {
                return
                    walker
                    .GetChildren(node)
                    .SelectMany(x => walker.GetLevel(x, depth - 1));
            }
        }
    }
}
