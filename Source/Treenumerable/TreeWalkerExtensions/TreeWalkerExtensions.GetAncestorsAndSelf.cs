using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a node and the node's ancestors, starting with its parent node and ending with
        /// the root node.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node whose ancestors are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains the node
        /// and all of the node's ancestors, up to and including the root.
        /// </returns>
        public static IEnumerable<T> GetAncestorsAndSelf<T>(this ITreeWalker<T> walker, T node)
        {
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }

            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            yield return node;
            foreach (T item in walker.GetAncestors(node))
            {
                yield return item;
            }
        }
    }
}
