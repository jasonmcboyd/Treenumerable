﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node"></param>
        /// <param name="includeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node, bool includeNode)
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

            // Loop over each child, calling PostOrderTraversal, and yield the results.
            foreach (T descendant in walker.GetChildren(node).SelectMany(x => walker.PostOrderTraversal(x, true)))
            {
                yield return descendant;
            }

            // If 'includeNode' is true then yield 'node'.
            if (includeNode)
            {
                yield return node;
            }
        }

        public static IEnumerable<T> PostOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.PostOrderTraversal(node, false);
        }
    }
}
