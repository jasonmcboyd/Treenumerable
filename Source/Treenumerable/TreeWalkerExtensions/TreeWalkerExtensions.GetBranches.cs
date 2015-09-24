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
                // Push enumerators onto the stack until we push an empty enumerator onto the
                // stack.  This is how we construct a branch.
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

                // The top enumerator does not have any items; pop it off the stack and yield the
                // current item from each enumerator on the stack in reverse.  This is a branch.
                enumerators.Pop().Dispose();
                yield return enumerators.ToReverseArray(x => x.Current);

                // Pop enumerators off the stack until the stack is empty or we get to an
                // enumerator that has a next item.
                while (enumerators.Count > 0 && !enumerators.Peek().MoveNext())
                {
                    enumerators.Pop().Dispose();
                }

                // If there is an enumerator on the stack then get the children of the enumerators
                // current item and push the enumerator of the children onto the stack.  We are
                // ready to start building the next branch.
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
