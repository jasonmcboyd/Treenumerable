using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetLevel(int depth)
        {
            return
                this
                .TreeWalker
                .GetLevel(this.Root, depth)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
