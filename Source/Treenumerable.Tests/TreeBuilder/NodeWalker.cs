using System.Collections.Generic;

namespace Treenumerable.Tests.TreeBuilder
{
    public class NodeWalker<T> : ITreeWalker<Node<T>>
    {
        public bool TryGetParent(Node<T> node, out Node<T> parent)
        {
            parent = node.Parent;
            return parent != null;
        }

        public IEnumerable<Node<T>> GetChildren(Node<T> node)
        {
            return node.Children;
        }
    }
}
