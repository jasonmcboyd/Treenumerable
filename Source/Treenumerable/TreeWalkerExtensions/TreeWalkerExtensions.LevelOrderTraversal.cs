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
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if the current node
        /// that is being evaluated (and all of its descendants) should be included in the 
        /// traversal.  This allows for short-circuiting of the level-order traversal by excluding
        /// particular subtrees from the traversal.  The first argument is the current node being
        /// evaluated and the second argument is the depth of the current node relative to the
        /// original node that the traversal began on.
        /// </param>
        /// <param name="excludeOption">
        /// Used in conjunction with the <paramref name="excludeSubtreePredicate"/>.  Determines
        /// if the entire subtree should be excluded or just its children.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the nodes
        /// in the tree ordered based on a level order traversal.
        /// </returns>
        public static IEnumerable<T> LevelOrderTraversal<T>(
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

            // Set the initial depth to 0.
            int depth = 0;

            // Set 'node' as the current level.
            IEnumerable<T> currentLevel = new T[] { node };
            IEnumerable<T> nextLevel = Enumerable.Empty<T>();

            // Enumerate 'currentLevel' and yield each node while adding that node's children to 
            // 'nextLevel'.  When complete: set 'currentLevel' equal to 'nextLevel', increment count
            // and repeat the process.
            while (currentLevel.Any())
            {
                foreach (T currentNode in currentLevel)
                {
                    // If the 'excludeSubtreePredicate' is not null and evaluates to true then
                    // exlucude this node and all of its descendants, depending on 'excludeOption',
                    // from the traversal result.
                    if (excludeSubtreePredicate != null && excludeSubtreePredicate.Invoke(currentNode, depth))
                    {
                        if (excludeOption == ExcludeOption.ExcludeChildren)
                        {
                            yield return currentNode;
                        }
                    }
                    else
                    {
                        yield return currentNode;
                        nextLevel = nextLevel.Concat(walker.GetChildren(currentNode));
                    }
                }

                currentLevel = nextLevel;
                nextLevel = Enumerable.Empty<T>();
                depth++;
            }
        }

        /// <summary>
        /// Enumerates a tree using the level traversal method.  I.e. it returns all nodes in the
        /// first level relative to the specified node, followed by all nodes in the second level,
        /// etc...
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child nodes.
        /// </param>
        /// <param name="node">The root node of the tree that is to be traversed.</param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all the nodes
        /// in the tree ordered based on a level order traversal.
        /// </returns>
        public static IEnumerable<T> LevelOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.LevelOrderTraversal(node, null, ExcludeOption.ExcludeTree);
        }

        
    }
}
