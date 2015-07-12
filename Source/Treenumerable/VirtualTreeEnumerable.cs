using System.Collections;
using System.Collections.Generic;

namespace Treenumerable
{
    public class VirtualTreeEnumerable<T> : IEnumerable<VirtualTree<T>>
    {
        public VirtualTreeEnumerable(IEnumerable<VirtualTree<T>> virtualTrees)
        {
            this._VirtualTrees = virtualTrees;
        }

        private readonly IEnumerable<VirtualTree<T>> _VirtualTrees;

        public IEnumerator<VirtualTree<T>> GetEnumerator()
        {
            return this._VirtualTrees.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<VirtualTree<T>> this[T key]
        {
            get
            {
                foreach (VirtualTree<T> tree in this._VirtualTrees.SelectChildren(key))
                {
                    yield return tree;
                }
            }
        }

        public IEnumerable<VirtualTree<T>> this[int index]
        {
            get
            {
                foreach (VirtualTree<T> tree in this._VirtualTrees)
                {
                    yield return tree[index];
                }
            }
        }
    }
}
