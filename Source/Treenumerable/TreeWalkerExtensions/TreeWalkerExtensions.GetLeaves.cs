using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets a node's leaves, i.e. all descendants of that node that do not have children.  If
        /// the node has no children then the node itself is returned.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose leaves are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the node's
        /// leaves.
        /// </returns>
        public static IEnumerable<T> GetLeaves<T>(this ITreeWalker<T> walker, T node)
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

            // Create a stack to hold enumerators and push the child enumerator of 'node'.
            Stack<IEnumerator<T>> stack = new Stack<IEnumerator<T>>();
            stack.Push(walker.GetChildren(node).GetEnumerator());

            if (!stack.Peek().MoveNext())
            {
                // If the enumerator on the stack has no items then 'node' is a leaf node.
                // Dispose of the enumerator and yield 'node' and we are done.
                stack.Pop().Dispose();
                yield return node;
            }
            else
            {
                // The current node is now the first child of the 'node' parameter.
                // Continue looping as long as the stack has enumerators on it.
                while (stack.Count > 0)
                {
                    // Push the current node's enumerator on the stack.
                    stack.Push(walker.GetChildren(stack.Peek().Current).GetEnumerator());

                    // Continue pushing enumerators on the stack as long the enumerator on the top
                    // of the stack has items.
                    while (stack.Peek().MoveNext())
                    {
                        stack.Push(walker.GetChildren(stack.Peek().Current).GetEnumerator());
                    }

                    // Once we reach an enumerator that has no items pop that enumerator and
                    // dispose of it.
                    stack.Pop().Dispose();

                    // The 'Current' property of the enumerator on the top of the stack is a leaf
                    // node.  Return it.
                    yield return stack.Peek().Current;

                    // Continue popping enumerators off of the stack and disposing of them until
                    // we reach an enumerator with another item.  That item become the current
                    // node.
                    while (stack.Count > 0 && !stack.Peek().MoveNext())
                    {
                        stack.Pop().Dispose();
                    }
                }
            }
        }
    }
}
