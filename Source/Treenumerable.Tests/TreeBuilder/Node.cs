using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Treenumerable.Tests.TreeBuilder
{
    public class Node<T>
    {
        public Node(T value)
        {
            this._Children = new ReadOnlyCollection<Node<T>>(this._InternalChildren);
            this.Value = value;
        }

        public Node<T> this[int index]
        {
            get
            {
                return this.Children[index];
            }
        }

        public T Value { get; private set; }
        public Node<T> Parent { get; private set; }

        private readonly List<Node<T>> _InternalChildren = new List<Node<T>>();
        private readonly IReadOnlyList<Node<T>> _Children;
        public IReadOnlyList<Node<T>> Children
        {
            get { return this._Children; }
        }

        public Node<T> AddChildren(params Node<T>[] nodes)
        {
            foreach (Node<T> node in nodes)
            {
                node.Parent = this;
                this._InternalChildren.Add(node);
            }

            return this;
        }
    }
}
