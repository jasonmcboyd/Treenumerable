using System.Collections.Generic;

namespace Treenumerable.Tests.TreeBuilder
{
    public class NodeWalker<T> : ITreeWalker<Node<T>>
    {
        public IEnumerable<Node<T>> GetAncestors(Node<T> node)
        {
            node = node.Parent;
            while (node != null)
            {
                yield return node;
                node = node.Parent;
            }
        }

        public IEnumerable<Node<T>> GetChildren(Node<T> node)
        {
            foreach (Node<T> child in node.Children)
            {
                yield return child;
            }
        }
    }
}
