using System;
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
        /// <returns></returns>
        public static IEnumerable<T> GetPrecedingSiblings<T>(this ITreeWalker<T> walker, T node)
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

            ParentNode<T> parentNode = walker.GetParentNode(node);
            if (parentNode.HasValue)
            {
                return walker.GetChildren(parentNode.Value).TakeWhile(x => !x.Equals(node));
            }
            else
            {
                return Enumerable.Empty<T>();
            }
        }

        public static IEnumerable<T> GetFollowingSiblings<T>(this ITreeWalker<T> walker, T node)
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

            ParentNode<T> parentNode = walker.GetParentNode(node);
            if (parentNode.HasValue)
            {
                return walker.GetChildren(parentNode.Value).SkipWhile(x => !x.Equals(node)).Skip(1);
            }
            else
            {
                return Enumerable.Empty<T>();
            }
        }
    }
}
