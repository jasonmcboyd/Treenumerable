namespace Treenumerable.Tests.TreeBuilder
{
    public static class Node
    {
        public static Node<T> Create<T>(T value)
        {
            return new Node<T>(value);
        }
    }
}
