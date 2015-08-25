using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the nearest descendants based on a predicate.
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

            // Create a stack to keep track of the branches being traversed.
            Stack<IEnumerator<T>> enumerators = new Stack<IEnumerator<T>>();

            foreach (T node in nodes)
            {
                enumerators
                .Push(
                    walker
                    .GetChildren(node)
                    .GetEnumerator());

                while (enumerators.Count > 0)
                {
                    // Try and move to the current node's next child.
                    if (enumerators.Peek().MoveNext())
                    {
                        // If we successfully moved to the next child then set the current node
                        // to that child.
                        T currentNode = enumerators.Peek().Current;

                        // If the predicate evaluates to true then yield the current node.
                        // Otherwise, push the node and its enumerator to the stacks.
                        if (predicate(currentNode, enumerators.Count))
                        {
                            yield return currentNode;
                        }
                        else
                        {
                            enumerators
                            .Push(
                                walker
                                .GetChildren(currentNode)
                                .GetEnumerator());
                        }
                    }
                    else
                    {
                        // If the current node does not have any more children then pop it off of
                        // the 'nodes' stack and pop its children enumerator off the 'enumerators'
                        // stack.
                        enumerators.Pop().Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the nearest descendants based on a predicate.
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
        /// A predicate to test each node for selection.  The argument is the current node being
        /// evaluated.
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
                .GetDescendants(
                    nodes,
                    (n, i) => predicate.Invoke(n));
        }

        /// <summary>
        /// Gets the nearest descendants based on a predicate.
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
                .GetDescendants(
                    new T[] { node },
                    predicate);
        }

        /// <summary>
        /// Gets the nearest descendants based on a predicate.
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
        /// A predicate to test each node for selection.  The argument is the current node being
        /// evaluated.
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
                .GetDescendants(
                    new T[] { node },
                    (n, i) => predicate.Invoke(n));
        }

        /// <summary>
        /// Gets the nearest descendants that match the <paramref name="key"/>.
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
        /// Gets the nearest descendants that match the <paramref name="key"/>.
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
        /// Gets the nearest descendants that match the <paramref name="key"/>.
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
        /// Gets the nearest descendants that match the <paramref name="key"/>.
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
