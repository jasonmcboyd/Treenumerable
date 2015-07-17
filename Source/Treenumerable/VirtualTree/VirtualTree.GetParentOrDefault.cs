namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public T GetParentOrDefault()
        {
            return
                this
                .TreeWalker
                .GetParentOrDefault(this.Root);
        }
    }
}
