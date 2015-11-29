using System;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetChildrenByKeyTests
    {
        [Fact]
        public void GetChildrenByKey_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetChildren' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetChildren(new Node<int>[] { tree }, default(Node<int>)).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetChildren(tree, default(Node<int>)).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetChildren(new Node<int>[] { tree }, default(Node<int>), EqualityComparer<Node<int>>.Default).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetChildren(tree, default(Node<int>), EqualityComparer<Node<int>>.Default).ToArray());
        }

        [Fact]
        public void GetChildrenByKey_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetChildren' throws an 'ArgumentNullException' when the node is
            // null.
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetChildren((IEnumerable<Node<int>>)null, default(Node<int>)).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetChildren((Node<int>)null, default(Node<int>)).ToArray());
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetChildren((IEnumerable<Node<int>>)null, default(Node<int>), EqualityComparer<Node<int>>.Default).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetChildren((Node<int>)null, default(Node<int>), EqualityComparer<Node<int>>.Default).ToArray());
        }

        [Fact]
        public void GetChildrenByKey_NullKey_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetChildren' throws an 'ArgumentNullException' when the key 
            // is null.
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetChildren(new Node<int>[] { tree }, (Node<int>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetChildren(tree, (Node<int>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetChildren(new Node<int>[] { tree }, (Node<int>)null, EqualityComparer<Node<int>>.Default).ToArray());
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetChildren(tree, (Node<int>)null, EqualityComparer<Node<int>>.Default).ToArray());
        }

        [Fact]
        public void GetChildrenByKey_ByKeyTests()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            foreach (Node<int> node in walker.PreOrderTraversal(tree))
            {
                foreach (Node<int> key in walker.PreOrderTraversal(tree))
                {
                    IEnumerable<Node<int>> result = walker.GetChildren(node, key).ToArray();
                    if (walker.GetChildren(node).Contains(key))
                    {
                        Assert.Equal(result, new Node<int>[] { key });
                    }
                    else
                    {
                        Assert.Empty(result);
                    }
                }
            }
        }
    }
}
