using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetChildren()
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> GetChildren(Func<T, bool> predicate)
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root, predicate)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> GetChildren(T key)
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root, key, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> GetChildren(T key, IEqualityComparer<T> comparer)
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root, key, comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
