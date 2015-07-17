namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public T GetRoot()
        {
            return
                this
                .TreeWalker
                .GetRoot(this.Root);
        }
    }
}
