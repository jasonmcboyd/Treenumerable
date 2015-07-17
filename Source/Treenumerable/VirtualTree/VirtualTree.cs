using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
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

        public IEqualityComparer<T> Comparer { get; private set; }

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
