namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public int GetDepth()
        {
            return
                this
                .TreeWalker
                .GetDepth(this.Root);
        }
    }
}
