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
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, Int32, Boolean&gt;"/> that determines if the current node
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
            // Validate parameters.
            if (walker == null)
            {
                throw new ArgumentNullException("walker");
            }

            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            // Create a stack to keep track of the branches being traversed.
            Stack<IEnumerator<T>> enumerators = new Stack<IEnumerator<T>>();
            enumerators.Push(Enumerable.Repeat(node, 1).GetEnumerator());

            // Loop as long as we have an enumerator on the stack.  When we have popped the last
            // one off the stack the traversal is complete.
            while (enumerators.Count > 0)
            {
                if (enumerators.Peek().MoveNext())
                {
                    node = enumerators.Peek().Current;

                    // If the 'excludeSubtreePredicate' is not null and evaluates to true then
                    // yield the current node if 'excludeOption' is set to exclude the children.
                    // Otherwise, do not yield anything.
                    if (excludeSubtreePredicate != null &&
                        excludeSubtreePredicate.Invoke(node, enumerators.Count - 1))
                    {
                        if (excludeOption == ExcludeOption.ExcludeDescendants)
                        {
                            yield return node;
                        }
                    }
                    else
                    {
                        // Yield the current node then push it and its children onto the 
                        // stack.
                        yield return node;
                        enumerators.Push(walker.GetChildren(node).GetEnumerator());
                    }
                }
                else
                {
                    // Pop the enumerator and dispose of it.
                    enumerators.Pop().Dispose();
                }
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
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the
        /// nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public static IEnumerable<T> PreOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PreOrderTraversal(node, null, ExcludeOption.ExcludeTree);
        }
    }
}
