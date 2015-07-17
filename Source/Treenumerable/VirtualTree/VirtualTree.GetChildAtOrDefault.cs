namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTree<T> GetChildAtOrDefault(int index)
        {
            T child;
            if (this.TreeWalker.TryGetChildAt(this.Root, index, out child))
            {
                return this.ShallowCopy(child);
            }
            else
            {
                return default(VirtualTree<T>);
            }
        }
    }
}
