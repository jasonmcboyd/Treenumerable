namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the height of the <see cref="Treenumerable.Virtual&lt;T&gt;"/>.  The height is
        /// measured by the number of edges between this and the deepest leaf.
        /// </summary>
        /// <returns>
        /// The number of edges between this and the deepest leaf.
        /// </returns>
        public int GetHeight()
        {
            return
                this
                .TreeWalker
                .GetHeight(this.Root);
        }
    }
}
