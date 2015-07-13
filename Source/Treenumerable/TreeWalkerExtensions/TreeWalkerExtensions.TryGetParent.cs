using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Tries to get a node's parent.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node whose parent is to be returned.
        /// </param>
        /// <param name="parent">
        /// A reference to the resulting parent node.  This will be a default value of type 
        /// <typeparamref name="T"/> if we fail to get a the parent node.
        /// </param>
        /// <returns>
        /// True if a parent node is found, false, otherwise.
        /// </returns>
        public static bool TryGetParent<T>(this ITreeWalker<T> walker, T node, out T parent)
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

            // Get the ancestors enumerator and attempt to move to the first node.
            // If we get the first node output it and return true.  Otherwise, output a default
            // node and return false.
            using (IEnumerator<T> enumerator = walker.GetAncestors(node).GetEnumerator())
            {
                if (enumerator.MoveNext())
                {
                    parent = enumerator.Current;
                    return true;
                }
                else
                {
                    parent = default(T);
                    return false;
                }
            }
        }
    }
}
