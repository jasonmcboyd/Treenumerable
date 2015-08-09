namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the depth of the <see cref="VirtualTree<&lt;T&gt;"/>.  The depth is measured by
        /// the number of edges between this and the root.
        /// </summary>
        /// <returns>
        /// The number of edges between this and the root of the tree.
        /// </returns>
        public int GetDepth()
        {
            return
                this
                .TreeWalker
                .GetDepth(this.Root);
        }
    }
}
