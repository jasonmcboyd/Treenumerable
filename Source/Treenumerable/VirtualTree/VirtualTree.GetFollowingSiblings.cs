namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTreeEnumerable<T> GetFollowingSiblings()
        {
            return
                this
                .TreeWalker
                .GetFollowingSiblings(this.Root, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
