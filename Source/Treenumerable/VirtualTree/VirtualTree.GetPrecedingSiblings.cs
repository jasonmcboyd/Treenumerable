namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetPrecedingSiblings()
        {
            return
                this
                .TreeWalker
                .GetPrecedingSiblings(this.Root, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
