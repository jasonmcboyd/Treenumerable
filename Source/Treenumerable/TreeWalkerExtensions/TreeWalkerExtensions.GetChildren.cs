using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets children based on a predicate.
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
        /// A predicate to test each child for selection.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching children.
        /// </returns>
        public static IEnumerable<T> GetChildren<T>(
            this ITreeWalker<T> walker,
            IEnumerable<T> nodes,
            Func<T, bool> predicate)
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

            return
                nodes
                .SelectMany(n => walker.GetChildren(n))
                .Where(predicate);
        }

        /// <summary>
        /// Gets children based on a predicate.
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
        /// A predicate to test each child for selection.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching children.
        /// </returns>
        public static IEnumerable<T> GetChildren<T>(
            this ITreeWalker<T> walker,
            T node,
            Func<T, bool> predicate)
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

            if (predicate == null)
            {
                throw new ArgumentNullException("predicate");
            }

            return
                walker
                .GetChildren(node)
                .Where(predicate);
        }
        
        /// <summary>
        /// Gets the children that match the <paramref name="key"/>.
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
        /// The key that each child will be compared to.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching children.
        /// </returns>
        public static IEnumerable<T> GetChildren<T>(
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

            return walker.GetChildren(nodes, key, null);
        }

        /// <summary>
        /// Gets the children that match the <paramref name="key"/>.
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
        /// The key that each child will be compared to.
        /// </param>
        /// <param name="comparer">
        /// The <see cref="IEqualityComparer&lt;T&gt;"/> used to compare the key and the child.  If
        /// this is null then the default <see cref="EqualityComparer&lt;T&gt;.Default"/> will be
        /// used.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching children.
        /// </returns>
        public static IEnumerable<T> GetChildren<T>(
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

            return
                nodes
                .SelectMany(n => walker.GetChildren(n))
                .Where(n => comparer.Equals(key, n));
        }

        /// <summary>
        /// Gets the children that match the <paramref name="key"/>.
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
        /// The key that each child will be compared to.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching children.
        /// </returns>
        public static IEnumerable<T> GetChildren<T>(
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

            return walker.GetChildren(node, key, null);
        }

        /// <summary>
        /// Gets the children that match the <paramref name="key"/>.
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
        /// The key that each child will be compared to.
        /// </param>
        /// <param name="comparer">
        /// The <see cref="IEqualityComparer&lt;T&gt;"/> used to compare the key and the child.  If
        /// this is null then the default <see cref="EqualityComparer&lt;T&gt;.Default"/> will be
        /// used.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// matching children.
        /// </returns>
        public static IEnumerable<T> GetChildren<T>(
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

            return
                walker
                .GetChildren(node)
                .Where(n => comparer.Equals(key, n));
        }
    }
}
