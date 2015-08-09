namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the degree of a <see cref="VirtualTree&lt;T&gt;"/> (number of children).
        /// </summary>
        /// <returns>
        /// The degree (number of children) of this <see cref="VirtualTree&lt;T&gt;"/>.
        /// </returns>
        public int GetDegree()
        {
            return
                this
                .TreeWalker
                .GetDegree(this.Root);
        }
    }
}
