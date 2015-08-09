namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the siblings, i.e. all <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> that
        /// share the same parent.
        /// </summary>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all of
        /// the siblings.
        /// </returns>
        public VirtualTreeEnumerable<T> GetSiblings()
        {
            return
                this
                .TreeWalker
                .GetSiblings(this.Root, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
