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
        /// Returns the parent of a node.
        /// </summary>
        /// <param name="node">The node whose parent is to be returned.</param>
        /// <returns>
        /// The <see cref="ParentNode"/> that represents node's parent (or lack of parent).
        /// </returns>
        ParentNode<T> GetParentNode(T node);

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
