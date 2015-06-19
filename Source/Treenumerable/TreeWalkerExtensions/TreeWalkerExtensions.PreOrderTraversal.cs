using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the pre-order traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the pre-order traversal by excluding
        /// particular subtrees from the traversal.  The first argument is the current node being
        /// evaluated and the second argument is the depth of the current node relative to the
        /// original node that the traversal began on.
        /// </param>
        /// <param name="excludeOption">
        /// Used in conjunction with the <paramref name="excludeSubtreePredicate"/>.  Determines
        /// if the entire subtree should be excluded or just its children.
        /// </param>
        /// <param name="depth">
        /// The depth of the current node being evaluated for traversal.  This is the number of
        /// edges from the original node that the traversal began on to the current node being
        /// evaluated.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        private static IEnumerable<T> PreOrderTraversalImplementation<T>(
            this ITreeWalker<T> walker,
            T node,
            Func<T, int, bool> excludeSubtreePredicate,
            ExcludeOption excludeOption,
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

            // If the 'excludeSubtreePredicate' is not null and evaluates to true then exlucude
            // this node and all of its descendants, depending on 'excludeOption', from the
            // traversal result.
            if (excludeSubtreePredicate != null && excludeSubtreePredicate.Invoke(node, depth))
            {
                if (excludeOption == ExcludeOption.ExcludeChildren)
                {
                    yield return node;
                }
                yield break;
            }
            else
            {
                yield return node;
            }
                        
            // Construct an IEnumerable to traverse the remaining nodes.
            IEnumerable<T> remainingNodes =
                walker
                .GetChildren(node)
                .SelectMany(x =>
                    walker
                    .PreOrderTraversalImplementation(
                        x,
                        excludeSubtreePredicate,
                        excludeOption,
                        depth + 1));

            // Recursively yield each descendant using the preorder traversal method.
            foreach (T descendant in remainingNodes)
            {
                yield return descendant;
            }
        }

        /// <summary>
        /// Enumerates a tree using the pre-order traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the pre-order traversal by excluding
        /// particular subtrees from the traversal.  The first argument is the current node being
        /// evaluated and the second argument is the depth of the current node relative to the
        /// original node that the traversal began on.
        /// </param>
        /// <param name="excludeOption">
        /// Used in conjunction with the <paramref name="excludeSubtreePredicate"/>.  Determines
        /// if the entire subtree should be excluded or just its children.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> PreOrderTraversal<T>(
            this ITreeWalker<T> walker, 
            T node, 
            Func<T, int, bool> excludeSubtreePredicate,
            ExcludeOption excludeOption)
        {
            return walker.PreOrderTraversalImplementation(node, excludeSubtreePredicate, excludeOption, 0);
        }

        /// <summary>
        /// Enumerates a tree using the pre-order traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> PreOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PreOrderTraversalImplementation(node, null, ExcludeOption.ExcludeTree, 0);
        }
    }
}
