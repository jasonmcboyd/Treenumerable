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
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        private static IEnumerable<T> GetDescendantsImplementation<T>(
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
                        .GetDescendantsImplementation(
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
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
            this ITreeWalker<T> walker,
            IEnumerable<T> nodes,
            Func<T, int, bool> predicate)
        {
            return
                walker
                .GetDescendantsImplementation(
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
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
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
                .GetDescendantsImplementation(
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
        /// <param name="node">
        /// The root node to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
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
                .GetDescendantsImplementation(
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
        /// <param name="node">
        /// The root node to be queried.
        /// </param>
        /// <param name="predicate">
        /// A predicate to test each node for selection.  The first argument is the current node
        /// being evaluated and the second argument is the depth of the current node relative to
        /// the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
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
                .GetDescendantsImplementation(
                    new T[] { node },
                    (n, i) => predicate.Invoke(n),
                    0);
        }

        /// <summary>
        /// Selects the nearest descendants that match the <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root nodes to be queried.
        /// </param>
        /// <param name="key">
        /// The key each node will be compared to.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
            this ITreeWalker<T> walker,
            IEnumerable<T> nodes,
            T key)
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

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return walker.GetDescendants(nodes, key, null);
        }

        /// <summary>
        /// Selects the nearest descendants that match the <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">
        /// The root nodes to be queried.
        /// </param>
        /// <param name="key">
        /// The key each node will be compared to.
        /// </param>
        /// <param name="comparer">
        /// The <see cref="IEqualityComparer&lt;T&gt;"/> used to compare the key and the node.  If
        /// this is null then the default <see cref="EqualityComparer&lt;T&gt;.Default"/> will be
        /// used.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
            this ITreeWalker<T> walker,
            IEnumerable<T> nodes,
            T key,
            IEqualityComparer<T> comparer)
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

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            // If the comparer is null then use the defautl comparer for that type.
            comparer = comparer ?? EqualityComparer<T>.Default;

            return walker.GetDescendants(nodes, n => comparer.Equals(n, key));
        }

        /// <summary>
        /// Selects the nearest descendants that match the <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The root node to be queried.
        /// </param>
        /// <param name="key">
        /// The key each node will be compared to.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
            this ITreeWalker<T> walker,
            T node,
            T key)
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

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            return walker.GetDescendants(node, key, null);
        }

        /// <summary>
        /// Selects the nearest descendants that match the <paramref name="key"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The root node to be queried.
        /// </param>
        /// <param name="key">
        /// The key each node will be compared to.
        /// </param>
        /// <param name="comparer">
        /// The <see cref="IEqualityComparer&lt;T&gt;"/> used to compare the key and the node.  If
        /// this is null then the default <see cref="EqualityComparer&lt;T&gt;.Default"/> will be
        /// used.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> GetDescendants<T>(
            this ITreeWalker<T> walker,
            T node,
            T key,
            IEqualityComparer<T> comparer)
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

            if (key == null)
            {
                throw new ArgumentNullException("key");
            }

            // If the comparer is null then use the defautl comparer for that type.
            comparer = comparer ?? EqualityComparer<T>.Default;

            return walker.GetDescendants(node, n => comparer.Equals(n, key));
        }
    }
}
