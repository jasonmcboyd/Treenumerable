using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treenumerable.Tests.TreeBuilder;

namespace Treenumerable.Tests
{
    public static class TestTreeFactory
    {
        public static Node<int> GetSimpleTree()
        {
            return
                Node.Create(0).AddChildren(
                    Node.Create(1).AddChildren(
                        Node.Create(2),
                        Node.Create(3)),
                    Node.Create(4).AddChildren(
                        Node.Create(5).AddChildren(
                            Node.Create(6))));
        }
    }
}
