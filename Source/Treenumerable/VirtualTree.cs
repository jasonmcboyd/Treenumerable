using System;

namespace Treenumerable
{
    public struct VirtualTree<T>
    {
        public VirtualTree(ITreeWalker<T> treeWalker, T root) : this()
        {
            if (treeWalker == null)
            {
                throw new ArgumentNullException("treeWalker");
            }

            this.TreeWalker = treeWalker;
            this.Root = root;
        }

        public ITreeWalker<T> TreeWalker { get; private set; }

        public T Root { get; private set; }
    }

    public static class VirtualTree
    {
        public static VirtualTree<T> Create<T>(ITreeWalker<T> treeWalker, T root)
        {
            return new VirtualTree<T>(treeWalker, root);
        }
    }
}
