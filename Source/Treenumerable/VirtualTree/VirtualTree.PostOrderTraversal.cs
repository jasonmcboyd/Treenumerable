using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public IEnumerable<T> PostOrderTraversal()
        {
            return
                this
                .TreeWalker
                .PostOrderTraversal(this.Root);
        }

        public IEnumerable<T> PostOrderTraversal(
            Func<T, int, bool> excludeSubtreePredicate,
            ExcludeOption excludeOption)
        {
            return
                this
                .TreeWalker
                .PostOrderTraversal(this.Root, excludeSubtreePredicate, excludeOption);
        }
    }
}
