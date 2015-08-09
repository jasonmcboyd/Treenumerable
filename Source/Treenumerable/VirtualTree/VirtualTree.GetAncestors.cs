namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the ancestors, starting with its parent node and ending with the root node.
        /// </summary>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt"/> that contains all of
        /// the VirtualTree's ancestors, up to and including the root.
        /// </returns>
        public VirtualTreeEnumerable<T> GetAncestors()
        {
            return 
                this
                .TreeWalker
                .GetAncestors(this.Root)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
