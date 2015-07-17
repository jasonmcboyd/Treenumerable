namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTree<T> GetChildAt(int index)
        {
            return
                this
                .ShallowCopy(
                    this
                    .TreeWalker
                    .GetChildAt(this.Root, index));
        }
    }
}
