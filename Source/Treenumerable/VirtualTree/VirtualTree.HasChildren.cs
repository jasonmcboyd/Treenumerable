namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Determines if this <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> has children.
        /// </summary>
        /// <returns>
        /// Returns a <see cref="System.Boolean"/> indicating whether or not this
        /// <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> has children.
        /// </returns>
        public bool HasChildren()
        {
            return
                this
                .TreeWalker
                .HasChildren(this.Root);
        }
    }
}
