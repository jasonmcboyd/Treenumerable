using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public IEnumerable<T> PreOrderTraversal()
        {
            return
                this
                .TreeWalker
                .PreOrderTraversal(this.Root);
        }

        public IEnumerable<T> PreOrderTraversal(
            Func<T, int, bool> excludeSubtreePredicate,
            ExcludeOption excludeOption)
        {
            return
                this
                .TreeWalker
                .PreOrderTraversal(this.Root, excludeSubtreePredicate, excludeOption);
        }
    }
}
