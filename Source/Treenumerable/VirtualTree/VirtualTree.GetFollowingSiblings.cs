namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets this <see cref="Treenumerable.VirtualTree&lt;T&gt;"/>'s following siblings, i.e.
        /// all <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> that share the same parent and
        /// follow the <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> in the parent's list of
        /// children.
        /// </summary>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all of
        /// the <see cref="Treenumerable.VirtualTree&lt;T&gt;"/>'s preceding siblings.
        /// </returns>
        public VirtualTreeEnumerable<T> GetFollowingSiblings()
        {
            return
                this
                .TreeWalker
                .GetFollowingSiblings(this.Root, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
