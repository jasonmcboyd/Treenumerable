using System;
using System.Collections.Generic;
using Treenumerable.Tests.TreeBuilder;

namespace Treenumerable.Tests
{
    public class NodeComparer<T> : IEqualityComparer<Node<T>>
    {
        public bool Equals(Node<T> x, Node<T> y)
        {
            return x.Value.Equals(y.Value);
        }

        public int GetHashCode(Node<T> obj)
        {
            throw new NotImplementedException();
        }
    }
}
