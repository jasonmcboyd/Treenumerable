namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the child at the specified index or a default value if the index is out of range.
        /// </summary>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <returns>
        /// The child <see cref="VirtualTree&lt;T&gt;"/> at the specified index or the default
        /// value.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the <paramref name="index"/> is less than zero.
        /// </exception>
        public VirtualTree<T> GetChildAtOrDefault(int index)
        {
            T child;
            if (this.TreeWalker.TryGetChildAt(this.Root, index, out child))
            {
                return this.ShallowCopy(child);
            }
            else
            {
                return default(VirtualTree<T>);
            }
        }
    }
}
