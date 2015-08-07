namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTree<T> GetRoot()
        {
            return
                this
                .ShallowCopy(
                    this
                    .TreeWalker
                    .GetRoot(this.Root));
        }
    }
}
