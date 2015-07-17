namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetAncestors()
        {
            return 
                this
                .TreeWalker
                .GetAncestors(this.Root)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
