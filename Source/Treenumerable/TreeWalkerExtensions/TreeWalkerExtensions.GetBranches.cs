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
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;System.Collections.Generic.IEnumerable&lt;T&gt;&gt;"/>
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

            Stack<T> nodes = new Stack<T>();
            Stack<IEnumerator<T>> enumerators = new Stack<IEnumerator<T>>();

            nodes.Push(node);
            enumerators.Push(walker.GetChildren(node).GetEnumerator());

            do
            {
                if (enumerators.Peek().MoveNext())
                {
                    nodes.Push(enumerators.Peek().Current);
                    enumerators.Push(walker.GetChildren(enumerators.Peek().Current).GetEnumerator());
                }
                else
                {
                    yield return nodes.ToReverseArray();
                    
                    nodes.Pop();
                    enumerators.Pop().Dispose();

                    while (enumerators.Count > 0 && !enumerators.Peek().MoveNext())
                    {
                        nodes.Pop();
                        enumerators.Pop().Dispose();
                    }
                    if (enumerators.Count > 0)
                    {
                        nodes.Push(enumerators.Peek().Current);
                        enumerators.Push(walker.GetChildren(enumerators.Peek().Current).GetEnumerator());
                    }
                }
            }
            while (enumerators.Count > 0);
        }
    }
}
