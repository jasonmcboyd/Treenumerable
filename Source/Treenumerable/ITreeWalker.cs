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
        /// Gets a node's ancestors, starting with its parent node and ending with the root node.
        /// </summary>
        /// <param name="node">
        /// The node whose ancestors are to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;T&gt;"/> that contains all of
        /// the node's ancestors, up to and including the root.
        /// </returns>
        IEnumerable<T> GetAncestors(T node);

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
