namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public int GetDegree()
        {
            return
                this
                .TreeWalker
                .GetDegree(this.Root);
        }
    }
}
