namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets VirtualTree and its ancestors, starting with its parent node and ending with the
        /// root node.
        /// </summary>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt"/> that contains the 
        /// VirtualTree and all of the VirtualTree's ancestors, up to and including the root.
        /// </returns>
        public VirtualTreeEnumerable<T> GetAncestorsAndSelf()
        {
            return 
                this
                .TreeWalker
                .GetAncestorsAndSelf(this.Root)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
