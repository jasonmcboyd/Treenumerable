using System;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTree<T> GetParent()
        {
            // Return the node's parent or a default node if the parent does not exist.
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
