using System.Collections.Generic;
using System.Linq;

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

        public bool ReturnChildrenAsList { get; set; }

        public IEnumerable<Node<T>> GetChildren(Node<T> node)
        {
            return
                this.ReturnChildrenAsList ?
                node.Children.ToList() :
                node.Children.Hide();
        }
    }
}
