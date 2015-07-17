namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public int GetHeight()
        {
            return
                this
                .TreeWalker
                .GetHeight(this.Root);
        }
    }
}
