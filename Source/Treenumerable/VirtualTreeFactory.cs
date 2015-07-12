using System.Collections.Generic;

namespace Treenumerable
{
    public static class VirtualTree
    {
        public static VirtualTree<T> New<T>(ITreeWalker<T> treeWalker, T root)
        {
            return new VirtualTree<T>(treeWalker, root);
        }

        public static VirtualTree<T> New<T>(
            ITreeWalker<T> treeWalker, 
            T root, 
            IEqualityComparer<T> comparer)
        {
            return new VirtualTree<T>(treeWalker, root, comparer);
        }
    }
}
