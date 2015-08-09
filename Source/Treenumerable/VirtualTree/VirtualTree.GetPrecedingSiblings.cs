namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets a <see cref="Treenumerable.VirtualTree&lt;T&gt;"/>'s preceding siblings, i.e. all
        /// <see cref="Treenumerable.VirtualTree&lt;T&gt;"/>s that share the same parent and
        /// precede the <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> in the parent's list of
        /// children.
        /// </summary>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all of
        /// the <see cref="Treenumerable.VirtualTree&lt;T&gt;"/>'s preceding siblings.
        /// </returns>
        public VirtualTreeEnumerable<T> GetPrecedingSiblings()
        {
            return
                this
                .TreeWalker
                .GetPrecedingSiblings(this.Root, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
