using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets all branches of a tree; a branch being a path from the root node to
        /// a leaf node.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">
        /// The node that all branches will start from.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.IList&lt;T&gt;&gt;"/>
        /// that contains all the branches.
        /// </returns>
        public static IEnumerable<IList<T>> GetBranches<T>(
            this ITreeWalker<T> walker, 
            T node)
        {
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
            
            // Loop as long as there are enumerators on the stack.
            while (enumerators.Count > 0)
            {
                while (enumerators.Peek().MoveNext())
                {
                    enumerators
                    .Push(
                        walker
                        .GetChildren(
                            enumerators
                            .Peek()
                            .Current)
                        .GetEnumerator());
                }

                // The current enumerator does have items pop it off the stack and yield the
                // reverse stack.
                enumerators.Pop().Dispose();
                yield return enumerators.ToReverseArray(x => x.Current);

                // Pop enumerators off the stack until we get to an enumerator that has a next
                // item or the stack is empty.
                while (enumerators.Count > 0 && !enumerators.Peek().MoveNext())
                {
                    enumerators.Pop().Dispose();
                }

                // If there is an enumerator on the stack the children of its current item onto
                // the stack.
                if (enumerators.Count > 0)
                {
                    enumerators
                    .Push(
                        walker
                        .GetChildren(
                            enumerators
                            .Peek()
                            .Current)
                        .GetEnumerator());
                }
            }
        }
    }
}
