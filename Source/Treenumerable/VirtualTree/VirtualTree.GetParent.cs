using System;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <returns>The parent.</returns>
        /// <exception cref="InvalidOperationException">
        /// When the there is no parent.
        /// </exception>
        public VirtualTree<T> GetParent()
        {
            // Return the node's parent or throws an exception if the parent does not exist.
            VirtualTree<T> parent;
            if (this.TryGetParent(out parent))
            {
                return parent;
            }
            else
            {
                throw new InvalidOperationException("The node does not have a parent.");
            }
        }
    }
}
