using System.Collections.Generic;

namespace Treenumerable.Tests.TreeBuilder
{
    public class NodeWalker<T> : ITreeWalker<Node<T>>
    {
        public ParentNode<Node<T>> GetParentNode(Node<T> node)
        {
            return
                node.Parent != null ?
                new ParentNode<Node<T>>(node.Parent) :
                default(ParentNode<Node<T>>);
        }

        public IEnumerable<Node<T>> GetChildren(Node<T> node)
        {
            return node.Children;
        }
    }
}
