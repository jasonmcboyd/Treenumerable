namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public bool HasChildren()
        {
            return
                this
                .TreeWalker
                .HasChildren(this.Root);
        }
    }
}
