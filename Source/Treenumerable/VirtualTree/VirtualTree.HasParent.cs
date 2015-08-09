namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Determines if this <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> has a parent.
        /// <returns>
        /// Returns a <see cref="System.Boolean"/> indicating whether or not this
        /// <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> has a parent.
        /// </returns>
        public bool HasParent()
        {
            return
                this
                .TreeWalker
                .HasParent(this.Root);
        }
    }
}
