namespace Treenumerable
{
    /// <summary>
    /// Provides helper methods for <see cref="ParentNode<T>"/>.
    /// </summary>
    public static class ParentNode
    {
        /// <summary>
        /// Instantiates a new <see cref="ParentNode"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="value">The value of the node.</param>
        /// <returns>The parent node.</returns>
        public static ParentNode<T> Create<T>(T value)
        {
            return new ParentNode<T>(value);
        }
    }
}
