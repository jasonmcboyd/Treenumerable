using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public IEnumerable<VirtualTree<T>> GetLeaves()
        {
            return
                this
                .TreeWalker
                .GetLeaves(this.Root)
                .ToVirtualTrees(this);
        }
    }
}
