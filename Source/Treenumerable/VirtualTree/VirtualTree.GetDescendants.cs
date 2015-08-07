using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetDescendants(Func<T, bool> predicate)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, predicate)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> GetDescendants(Func<T, int, bool> predicate)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, predicate)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> GetDescendants(T key)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, key, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> GetDescendants(T key, IEqualityComparer<T> comparer)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, key, comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
