namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetSiblings()
        {
            return
                this
                .TreeWalker
                .GetSiblings(this.Root)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
