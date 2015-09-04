using System;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the root node of a tree given a node in that tree.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node from which the search for the root node will begin.
        /// </param>
        /// <returns>
        /// The root node of a tree.
        /// </returns>
        public static T GetRoot<T>(this ITreeWalker<T> walker, T node)
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
            
            // Get the node's ancestors and return the last one, or the node itself , if the node
            // has no ancestors.
            return
                walker
                .GetAncestorsAndSelf(node)
                .Last();
        }
    }
}
