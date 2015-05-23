using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the level traversal method.  I.e. it returns all nodes in the
        /// first level relative to the specified node, followed by all nodes in the second level,
        /// etc...
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="includeNode">
        /// Indicates whether or not the <paramref name="node"/> is to be included in the resulting
        /// <see cref="System.Collections.Generic.IEnumerable<T>"/>.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable<T>"/> that contains all the nodes
        /// in the tree ordered based on a level order traversal.
        /// </returns>
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

            // Add the current node's children to the 'nextLevel' enumerable.
            IEnumerable<T> nextLevel = walker.GetChildren(node);
            IEnumerable<T> followingLevel = Enumerable.Empty<T>();

            // Enumerate 'nextLevel' and yield each node while adding that node's children to 
            // 'followingLevel'.  When complete set 'nextLevel' equal to 'followingLevel' and 
            // repeat the process.
            while (nextLevel.Any())
            {
                foreach (T currentNode in nextLevel)
                {
                    yield return currentNode;
                    followingLevel = followingLevel.Concat(walker.GetChildren(currentNode));
                }

                nextLevel = followingLevel;
                followingLevel = Enumerable.Empty<T>();
            }
        }

        /// <summary>
        /// Enumerates a tree using the level traversal method.  I.e. it returns all nodes in the
        /// first level relative to the specified node, followed by all nodes in the second level,
        /// etc...
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker<T>"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable<T>"/> that contains all the nodes
        /// in the tree ordered based on a level order traversal.
        /// </returns>
        public static IEnumerable<T> LevelOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.LevelOrderTraversal(node, false);
        }
    }
}
