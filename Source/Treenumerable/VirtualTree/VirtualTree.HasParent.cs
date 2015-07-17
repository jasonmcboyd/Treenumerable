namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public bool HasParent()
        {
            return
                this
                .TreeWalker
                .HasParent(this.Root);
        }
    }
}
