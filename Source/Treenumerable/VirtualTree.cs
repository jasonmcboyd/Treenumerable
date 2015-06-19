using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public struct VirtualTree<T>
    {
        public VirtualTree(ITreeWalker<T> treeWalker, T root) 
            : this(treeWalker, root, null)
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }

            this.TreeWalker = treeWalker;
            this.Root = root;
        }

        public VirtualTree(ITreeWalker<T> treeWalker, T root, IEqualityComparer<T> comparer)
            : this()
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }

            this.TreeWalker = treeWalker;
            this.Root = root;
            this.Comparer = comparer ?? EqualityComparer<T>.Default;
        }

        public ITreeWalker<T> TreeWalker { get; private set; }

        public T Root { get; private set; }

        private IEqualityComparer<T> Comparer { get; set; }

        public bool TryGetParent(out VirtualTree<T> parent)
        {
            T parentValue;
            bool result = this.TreeWalker.TryGetParent(this.Root, out parentValue);
            parent = 
                result ? 
                new VirtualTree<T>(this.TreeWalker, parentValue) : 
                default(VirtualTree<T>);
            return result;
        }

        public IEnumerable<VirtualTree<T>> GetChildren()
        {
            foreach (T child in this.TreeWalker.GetChildren(this.Root))
            {
                yield return new VirtualTree<T>(this.TreeWalker, child);
            }
        }

        public IEnumerable<VirtualTree<T>> this[T key]
        {
            get 
            {
                foreach (T child in this.TreeWalker.GetChildren(this.Root))
                {
                    if (this.Comparer.Equals(child, key))
                    {
                        yield return new VirtualTree<T>(this.TreeWalker, child);
                    }
                }
            }
        }
    }
}
