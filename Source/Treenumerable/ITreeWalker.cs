using System.Collections.Generic;

namespace Treenumerable
{
    /// <summary>
    /// Represents an object that is capable of getting the parent and child nodes of a node in a
    /// tree.
    /// </summary>
    /// <typeparam name="T">The type of elements in the tree.</typeparam>
    public interface ITreeWalker<T>
    {
        /// <summary>
        /// Returns a <see cref="System.Boolean"/> that indicates if a parent node exists.
        /// </summary>
        /// <param name="node">The node whose parent is to be returned.</param>
        /// <param name="parent">The parent node, if one exists.</param>
        /// <returns>
        /// When this method returns true this parameter will contain the <see cref="ParentNode"/>
        /// that represents the parent of the <paramref name="node"/> parameter.  When this method
        /// returns false the behavior of this parameter is undefined.
        /// </returns>
        bool TryGetParent(T node, out T parent);

        /// <summary>
        /// Returns the children of a node.
        /// </summary>
        /// <param name="node">The node whose children are to be returned.</param>
        /// <returns>
        /// The node's children.  This should never return null.  If a node has no children then
        /// an empty IEnumerable should be returned.
        /// </returns>
        IEnumerable<T> GetChildren(T node);
    }
}
