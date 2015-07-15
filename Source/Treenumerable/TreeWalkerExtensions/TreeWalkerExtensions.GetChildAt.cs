using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the child at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">The nodes whose children are to be returned.</param>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>
        /// The child node at the specified index for each of the nodes in <see cref="nodes"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is less than 0 or greater than or equal to the number of children.
        /// </exception>
        public static IEnumerable<T> GetChildAt<T>(this ITreeWalker<T> walker, IEnumerable<T> nodes, int index)
        {
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }

            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            foreach (T node in nodes)
            {
                T child;
                if (walker.TryGetChildAt(node, index, out child))
                {
                    yield return child;
                }
            }
        }

        /// <summary>
        /// Gets the child at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">The node whose child is to be returned.</param>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>The child node at the specified index.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is less than 0 or greater than or equal to the number of children.
        /// </exception>
        public static T GetChildAt<T>(this ITreeWalker<T> walker, T node, int index)
        {
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }

            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            T child;
            if (walker.TryGetChildAt(node, index, out child))
            {
                return child;
            }
            else
            {
                throw new ArgumentOutOfRangeException("index");
            }
        }
    }
}
