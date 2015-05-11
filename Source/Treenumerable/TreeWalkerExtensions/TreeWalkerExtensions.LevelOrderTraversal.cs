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
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node"></param>
        /// <param name="includeNode"></param>
        /// <returns></returns>
        public static IEnumerable<T> LevelOrderTraversal<T>(this ITreeWalker<T> walker, T node, bool includeNode)
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

            // If 'includeNode' is true then yield the root node.
            if (includeNode)
            {
                yield return node;
            }

            IEnumerable<T> currentLevel = walker.GetChildren(node);
            IEnumerable<T> nextLevel = Enumerable.Empty<T>();
            while (currentLevel.Any())
            {
                foreach (T currentNode in currentLevel)
                {
                    yield return currentNode;
                    nextLevel = nextLevel.Concat(walker.GetChildren(currentNode));
                }

                currentLevel = nextLevel;
                nextLevel = Enumerable.Empty<T>();
            }
        }

        public static IEnumerable<T> LevelOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.LevelOrderTraversal(node, false);
        }
    }
}
