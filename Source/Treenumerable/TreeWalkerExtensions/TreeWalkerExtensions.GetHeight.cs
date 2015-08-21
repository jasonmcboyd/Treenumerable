using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the height of the node.  The height is measured by the number of edges between
        /// <paramref name="node"/> and the deepest leaf.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The node whose height is to be returned.
        /// </param>
        /// <returns>
        /// The number of edges between <paramref name="node"/> and the deepest leaf.
        /// </returns>
        public static int GetHeight<T>(this ITreeWalker<T> walker, T node)
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

            // Keep track of the max height.
            int height = 0;

            // Continue looping as long as the stack has enumerators on it.
            // If an enumerator has an item push that item's child enumerator on the stack and
            // update 'height'.  Otherwise, pop the enumerator off the stack and dispose of it.
            while (stack.Count > 0)
            {
                if (stack.Peek().MoveNext())
                {
                    stack.Push(walker.GetChildren(stack.Peek().Current).GetEnumerator());
                    // If the stack height (minus one because height is zero based) is greater
                    // than the current height then update the current height.
                    if (stack.Count - 1 > height)
                    {
                        height = stack.Count - 1;
                    }
                }
                else
                {
                    stack.Pop().Dispose();
                }
            }

            return height;
        }
    }
}
