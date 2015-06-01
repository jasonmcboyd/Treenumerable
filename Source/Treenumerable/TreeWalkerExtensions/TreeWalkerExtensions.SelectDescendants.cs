using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Selects the nearest descendants based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root nodes to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <param name="depth">
        /// The depth of the current node being evaluated for selection.  This is the number of
        /// edges from the original node that the query began on to the current node being
        /// evaluated.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        private static IEnumerable<T> SelectDescendantsImplementation<T>(
            this ITreeWalker<T> walker,
            IEnumerable<T> nodes,
            Func<T, int, bool> predicate,
            int depth)
        {
            // Validate parameters.
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }
            
            if (nodes == null)
            {
                throw new ArgumentNullException("nodes");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            // Loop over each node and yield the node if it satisfies the predicate, otherwise,
            // query the node's children.
            foreach (T node in nodes)
            {
                if (predicate.Invoke(node, depth))
                {
                    yield return node;
                }
                else
                {
                    // Construct an IEnumerable to query the node's children.
                    IEnumerable<T> descendants =
                        walker
                        .SelectDescendantsImplementation(
                            walker.GetChildren(node),
                            predicate,
                            depth + 1);

                    // Recursively yield each selected descendant.
                    foreach (T descendant in descendants)
                    {
                        yield return descendant;
                    }
                }
            }
        }

        /// <summary>
        /// Selects the nearest descendants based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root nodes to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> SelectDescendants<T>(
            this ITreeWalker<T> walker, 
            IEnumerable<T> nodes, 
            Func<T, int, bool> predicate)
        {
            return 
                walker
                .SelectDescendantsImplementation(
                    nodes, 
                    predicate, 
                    0);
        }

        /// <summary>
        /// Selects the nearest descendants based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root nodes to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> SelectDescendants<T>(
            this ITreeWalker<T> walker, 
            IEnumerable<T> nodes, 
            Func<T, bool> predicate)
        {
            // Validate parameters.
            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return 
                walker
                .SelectDescendantsImplementation(
                    nodes, 
                    (n, i) => predicate.Invoke(n),
                    0);
        }

        /// <summary>
        /// Selects the nearest descendants based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root node to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> SelectDescendants<T>(
            this ITreeWalker<T> walker, 
            T node, 
            Func<T, int, bool> predicate)
        {
            // Validate parameters.
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            return 
                walker
                .SelectDescendantsImplementation(
                    new T[] { node }, 
                    predicate,
                    0);
        }

        /// <summary>
        /// Selects the nearest descendants based on a predicate.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root node to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> SelectDescendants<T>(
            this ITreeWalker<T> walker, 
            T node, 
            Func<T, bool> predicate)
        {
            // Validate parameters.
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return
                walker
                .SelectDescendantsImplementation(
                    new T[] { node },
                    (n, i) => predicate.Invoke(n),
                    0);
        }
    }
}
