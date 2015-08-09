namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the child at the specified index.
        /// </summary>
        /// <param name="index">The index of the child to retieve.</param>
        /// <returns>
        /// The child <see cref="VirtualTree&lt;T&gt;"/> at the specified index.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown if the index is less than 0 or greater than or equal to the number of children.
        /// </exception>
        public VirtualTree<T> GetChildAt(int index)
        {
            return
                this
                .ShallowCopy(
                    this
                    .TreeWalker
                    .GetChildAt(this.Root, index));
        }
    }
}
