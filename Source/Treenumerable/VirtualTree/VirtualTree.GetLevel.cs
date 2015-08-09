namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Returns all <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> at a depth relative to it.
        /// </summary>
        /// <param name="depth">
        /// The depth of the level to be returned.  This must be a nonnegative number.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// descendants at <paramref name="depth"/>.
        /// </returns>
        public VirtualTreeEnumerable<T> GetLevel(int depth)
        {
            return
                this
                .TreeWalker
                .GetLevel(this.Root, depth)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
