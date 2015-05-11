namespace Treenumerable
{
    /// <summary>
    /// Represents a node's parent.
    /// </summary>
    /// <typeparam name="T">The type of elements in the tree.</typeparam>
    public struct ParentNode<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParentNode<T>"/> struct.
        /// </summary>
        /// <param name="value">The value of the node.</param>
        public ParentNode(T value)
            : this()
        {
            this.Value = value;
            this.HasValue = true;
        }

        /// <summary>
        /// Gets the value of the node.
        /// </summary>
        public T Value { get; private set; }

        /// <summary>
        /// Gets a value indicating whether or not the node has a value.
        /// </summary>
        public bool HasValue { get; private set; }
    }
}
