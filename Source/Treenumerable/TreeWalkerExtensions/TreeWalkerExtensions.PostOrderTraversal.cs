﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="includeNode">
        /// Indicates whether or not the <paramref name="node"/> is to be included in the resulting
        /// <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>.
        /// </param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the postorder traversal by excluding
        /// particular subtrees from the traversal.  The first argument is the current node being
        /// evaluated and the second argument is the depth of the current node relative to the
        /// original node that the traversal began on.
        /// </param>
        /// <param name="depth">
        /// The depth of the current node being evaluated for traversal.  The is the number of
        /// edges from the original node that the traversal began on to the current node being
        /// evaluated.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        private static IEnumerable<T> PostOrderTraversalImplementation<T>(
            this ITreeWalker<T> walker,
            T node,
            bool includeNode,
            Func<T, int, bool> excludeSubtreePredicate,
            int depth)
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

            // If the 'excludeSubtreePredicate' is not null and evaluates to true then
            // terminiate the traversal of this node and all of its descendants by returning
            // an empty enumerable.
            if (excludeSubtreePredicate != null && excludeSubtreePredicate.Invoke(node, depth))
            {
                yield break;
            }

            // Construct an IEnumerable to traverse the remaining nodes.
            IEnumerable<T> remainingNodes =
                walker
                .GetChildren(node)
                .SelectMany(x =>
                    walker
                    .PostOrderTraversalImplementation(
                        x,
                        true,
                        excludeSubtreePredicate,
                        depth + 1));

            // Recursively yield each descendant using the postorder traversal method.
            foreach (T descendant in remainingNodes)
            {
                yield return descendant;
            }

            // If 'includeNode' is true then yield the root node.
            if (includeNode)
            {
                yield return node;
            }
        }

        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="includeNode">
        /// Indicates whether or not the <paramref name="node"/> is to be included in the resulting
        /// <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>.
        /// </param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the postorder traversal by excluding
        /// particular subtrees from the traversal.  The first argument is the current node being
        /// evaluated and the second argument is the depth of the current node relative to the
        /// original node that the traversal began on.
        /// </param>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node, bool includeNode, Func<T, int, bool> excludeSubtreePredicate)
        {
            return walker.PostOrderTraversalImplementation(node, includeNode, excludeSubtreePredicate, 0);
        }

        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="includeNode">
        /// Indicates whether or not the <paramref name="node"/> is to be included in the resulting
        /// <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/>.
        /// </param>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node, bool includeNode)
        {
            return walker.PostOrderTraversalImplementation(node, includeNode, null, 0);
        }

        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the postorder traversal by excluding
        /// particular subtrees from the traversal.  The first argument is the current node being
        /// evaluated and the second argument is the depth of the current node relative to the
        /// original node that the traversal began on.
        /// </param>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node, Func<T, int, bool> excludeSubtreePredicate)
        {
            return walker.PostOrderTraversalImplementation(node, false, excludeSubtreePredicate, 0);
        }

        /// <summary>
        /// Enumerates a tree using the postorder traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a preorder traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PostOrderTraversal(node, false);
        }
    }
}
