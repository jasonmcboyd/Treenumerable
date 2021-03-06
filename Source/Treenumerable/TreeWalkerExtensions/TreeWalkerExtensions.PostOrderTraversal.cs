﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the post-order traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, Int32, Boolean&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the post-order traversal by excluding
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
        /// nodes in the tree ordered based on a post-order traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(
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
                    if (excludeSubtreePredicate != null && excludeSubtreePredicate.Invoke(node, enumerators.Count - 1))
                    {
                        if (excludeOption == ExcludeOption.ExcludeDescendants)
                        {
                            yield return node;
                        }
                    }
                    else
                    {
                        // Push the current node's children onto the stack.
                        enumerators.Push(walker.GetChildren(node).GetEnumerator());
                    }
                }
                else
                {
                    // Pop the enumerator and dispose of it.
                    enumerators.Pop().Dispose();
                    
                    // Yield the 'Current' value of the enumerator on the top of the stack.
                    if (enumerators.Count > 0)
                    {
                        yield return enumerators.Peek().Current;
                    }
                }
            }

            //// If the 'excludeSubtreePredicate' is not null and evaluates to true then return
            //// 'node' or return an empty collection, depending on 'excludeOption'.
            //if (excludeSubtreePredicate != null && excludeSubtreePredicate.Invoke(node, 0))
            //{
            //    if (excludeOption == ExcludeOption.ExcludeDescendants)
            //    {
            //        yield return node;
            //    }
            //    yield break;
            //}
            //else
            //{
            //    // Create stacks to keep track of the branches being traversed.
            //    Stack<IEnumerator<T>> enumerators = new Stack<IEnumerator<T>>();
            //    Stack<T> nodes = new Stack<T>();

            //    // Push the current node and its children onto the stacks.
            //    nodes.Push(node);
            //    enumerators.Push(walker.GetChildren(node).GetEnumerator());

            //    // Loop as long as we have a node on the stack.  When we have popped the last node
            //    // off the stack the traversal is complete.
            //    while (nodes.Count > 0)
            //    {
            //        // Try and move to the current node's next child.
            //        if (enumerators.Peek().MoveNext())
            //        {
            //            // If we successfully moved to the next child then set the current node
            //            // to that child.
            //            node = enumerators.Peek().Current;

            //            // If the 'excludeSubtreePredicate' is not null and evaluates to true then
            //            // return yield the current node if 'excludeOption' is set to exclude the
            //            // children.  Otherwise, do not yield anything.
            //            if (excludeSubtreePredicate != null &&
            //                excludeSubtreePredicate.Invoke(node, nodes.Count))
            //            {
            //                if (excludeOption == ExcludeOption.ExcludeDescendants)
            //                {
            //                    yield return node;
            //                }
            //            }
            //            else
            //            {
            //                // Push the current node and its children onto the stacks.
            //                nodes.Push(node);
            //                enumerators.Push(walker.GetChildren(node).GetEnumerator());
            //            }
            //        }
            //        else
            //        {
            //            // If the current node does not have any more children then pop it off of
            //            // the 'nodes' stack and pop its children enumerator off the 'enumerators'
            //            // stack.
            //            // Yield the node that was popped off the stack.
            //            enumerators.Pop().Dispose();
            //            yield return nodes.Pop();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Enumerates a tree using the post-order traversal method.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a post-order traversal.
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the 
        /// nodes in the tree ordered based on a post-order traversal.
        /// </returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PostOrderTraversal(node, null, ExcludeOption.ExcludeTree);
        }
    }
}
