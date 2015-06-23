using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Gets the child at the specified index or the default value of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">The nodes whose children are to be returned.</param>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>
        /// The child node at the specified index or default values for each of the nodes in 
        /// <see cref="nodes"/>.
        /// </returns>
        public static IEnumerable<T> GetChildAtOrDefault<T>(this ITreeWalker<T> walker, IEnumerable<T> nodes, int index)
        {
            return
                nodes
                .Select(n => walker.GetChildren(n).ElementAtOrDefault(index));
        }

        /// <summary>
        /// Gets the child at the specified index or the default value of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="node">The node whose child is to be returned.</param>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>The child node at the specified index or the default value.</returns>
        public static T GetChildAtOrDefault<T>(this ITreeWalker<T> walker, T node, int index)
        {
            return
                walker
                .GetChildren(node)
                .ElementAtOrDefault(index);
        }
    }
}
