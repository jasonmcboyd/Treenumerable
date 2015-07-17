using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public IEnumerable<T> LevelOrderTraversal()
        {
            return
                this
                .TreeWalker
                .LevelOrderTraversal(this.Root);
        }

        public IEnumerable<T> LevelOrderTraversal(
            Func<T, int, bool> predicate,
            ExcludeOption excludeOption)
        {
            return
                this
                .TreeWalker
                .LevelOrderTraversal(this.Root, predicate, excludeOption);
        }
    }
}
