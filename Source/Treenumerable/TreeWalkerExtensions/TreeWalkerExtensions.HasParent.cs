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
        public static bool HasParent<T>(this ITreeWalker<T> walker, T node)
        {
            return !walker.GetParentNode(node).HasValue;
        }
    }
}
