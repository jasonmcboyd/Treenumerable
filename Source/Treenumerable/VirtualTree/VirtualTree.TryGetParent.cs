namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public bool TryGetParent(out VirtualTree<T> parent)
        {
            T parentNode;
            if (this.TreeWalker.TryGetParent(this.Root, out parentNode))
            {
                parent = this.ShallowCopy(parentNode);
                return true;
            }
            else
            {
                parent = default(VirtualTree<T>);
                return false;
            }
        }
    }
}
