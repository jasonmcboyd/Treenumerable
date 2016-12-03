using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Enumerates a tree using the level-order traversal method. I.e. it
        /// returns all nodes in the first level relative to the specified node,
        /// followed by all nodes in the second level, etc...
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the
        /// parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The root node of the tree that is to be traversed.
        /// </param>
        /// <param name="excludeSubtreePredicate">
        /// A <see cref="System.Func&lt;T, int, bool&gt;"/> that determines if
        /// the current node that is being evaluated (and all of its descendants)
        /// should be included in the traversal. This allows for short-circuiting
        /// of the level-order traversal by excluding particular subtrees from
        /// the traversal. The first argument is the current node being evaluated
        /// and the second argument is the depth of the current node relative to
        /// the original node that the traversal began on.
        /// </param>
        /// <param name="excludeOption">
        /// Used in conjunction with the <paramref
        /// name="excludeSubtreePredicate"/>. Determines if the entire subtree
        /// should be excluded or just its children.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that
        /// contains all the nodes in the tree ordered based on a level-order
        /// traversal.
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
            List<IEnumerable<T>> currentLevel = new List<IEnumerable<T>>()
            {
                new T[] { node }
            };
            List<IEnumerable<T>> nextLevel = new List<IEnumerable<T>>();

            // Track whether the current level has any nodes. This is true
            // initially since the current level is simply the node that was
            // passed to this function.
            bool currentLevelHasNodes = true;

            // Enumerate 'currentLevel' and yield each node while adding that
            // node's children to 'nextLevel'. When complete: set 'currentLevel'
            // equal to 'nextLevel', increment 'depth' and repeat the process.
            while (currentLevelHasNodes)
            {
                // Set current level has nodes to false when we enter the loop.
                // This will be set to true again if any nodes are concatenated
                // to 'nextLevel'.
                currentLevelHasNodes = false;
                foreach (T currentNode in currentLevel.SelectMany(x => x))
                {
                    // If the 'excludeSubtreePredicate' is not null and evaluates
                    // to true then exlucude this node and all of its
                    // descendants, depending on 'excludeOption', from the
                    // traversal result.
                    if (excludeSubtreePredicate != null && excludeSubtreePredicate.Invoke(currentNode, depth))
                    {
                        if (excludeOption == ExcludeOption.ExcludeDescendants)
                        {
                            yield return currentNode;
                        }
                    }
                    else
                    {
                        yield return currentNode;
                        nextLevel.Add(walker.GetChildren(currentNode));
                        currentLevelHasNodes = true;
                    }
                }

                // Swap the lists. I am reusing lists rather than simply creating
                // a new empty list so that there are fewer objects to be garbage
                // collected.
                var temp = currentLevel;
                currentLevel = nextLevel;
                nextLevel = temp;
                nextLevel.Clear();

                // Increment the depth counter.
                depth++;
            }
        }

        /// <summary>
        /// Enumerates a tree using the level traversal method. I.e. it returns
        /// all nodes in the first level relative to the specified node, followed
        /// by all nodes in the second level, etc...
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the
        /// parent and child nodes.
        /// </param>
        /// <param name="node">
        /// The root node of the tree that is to be traversed.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that
        /// contains all the nodes in the tree ordered based on a level-order
        /// traversal.
        /// </returns>
        public static IEnumerable<T> LevelOrderTraversal<T>(this ITreeWalker<T> walker, T node)
        {
            return walker.LevelOrderTraversal(node, null, ExcludeOption.ExcludeTree);
        }
    }
}
