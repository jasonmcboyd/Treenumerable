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

        public VirtualTree<T> ShallowCopy(T root)
        {
            return new VirtualTree<T>(this.TreeWalker, root, this.Comparer);
        }

        public ITreeWalker<T> TreeWalker { get; private set; }

        public T Root { get; private set; }

        public IEqualityComparer<T> Comparer { get; private set; }

        private IEnumerable<VirtualTree<T>> GetAncestorsImplementation()
        {
            foreach (T ancestor in this.TreeWalker.GetAncestors(this.Root))
            {
                yield return this.ShallowCopy(ancestor);
            }
        }

        public VirtualTreeEnumerable<T> GetAncestors()
        {
            return 
                this
                .GetAncestorsImplementation()
                .AsVirtualTreeEnumerable();
        }
        
        private IEnumerable<VirtualTree<T>> GetChildrenImplementation()
        {
            foreach (T child in this.TreeWalker.GetChildren(this.Root))
            {
                yield return this.ShallowCopy(child);
            }
        }

        public VirtualTreeEnumerable<T> GetChildren()
        {
            return
                this
                .GetChildrenImplementation()
                .AsVirtualTreeEnumerable();
        }

        public VirtualTreeEnumerable<T> this[T key]
        {
            get 
            {
                return
                    this
                    .GetChildren(key:key)
                    .AsVirtualTreeEnumerable();
            }
        }

        public VirtualTree<T> this[int index]
        {
            get
            {
                return
                    this
                    .GetChildAt(index);
            }
        }
    }
}
