namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTree<T> ShallowCopy(T root)
        {
            return new VirtualTree<T>(this.TreeWalker, root, this.Comparer);
        }
    }
}
