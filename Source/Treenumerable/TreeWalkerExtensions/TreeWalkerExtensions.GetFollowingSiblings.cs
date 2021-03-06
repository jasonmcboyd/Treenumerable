﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a node's following siblings, i.e. all nodes that share the same parent and follow
        /// the node in the parent's list of children.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node whose siblings are to be returned.
        /// </param>
        /// <param name="comparer">
        /// An <see cref="System.Collections.Generic.IEqualityComparer&lt;T&gt;"/> that knows how
        /// to compare two nodes for equality.  This is used to make sure that 
        /// <paramref name="node"/> is not returned in the resulting 
        /// <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains the
        /// siblings.
        /// </returns>
        public static IEnumerable<T> GetFollowingSiblings<T>(this ITreeWalker<T> walker, T node, IEqualityComparer<T> comparer)
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

            // If the comparer is null then use the default comparer.
            if (comparer == null)
            {
                comparer = EqualityComparer<T>.Default;
            }

            // Get the node's parent.
            T parent;
            if (walker.TryGetParent(node, out parent))
            {
                // Return all of the parent's children after the original node.
                using (IEnumerator<T> enumerator = walker.GetChildren(parent).GetEnumerator())
                {
                    while (enumerator.MoveNext() && !comparer.Equals(enumerator.Current, node))
                        ;

                    while (enumerator.MoveNext())
                    {
                        yield return enumerator.Current;
                    }
                }
            }
            else
            {
                // If the node does not have a parent then return an empty IEnumerable.
                yield break;
            }
        }

        /// <summary>
        /// Gets a node's following siblings, i.e. all nodes that share the same parent and follow
        /// the node in the parent's list of children.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node whose siblings are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all of
        /// the node's preceding siblings.
        /// </returns>
        public static IEnumerable<T> GetFollowingSiblings<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.GetFollowingSiblings<T>(node, EqualityComparer<T>.Default);
        }
    }
}
