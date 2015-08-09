namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <returns>
        /// The root.
        /// </returns>
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
