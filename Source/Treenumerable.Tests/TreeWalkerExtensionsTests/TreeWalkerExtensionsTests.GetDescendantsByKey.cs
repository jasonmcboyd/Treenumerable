using System;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetDescendants_ByKey_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetDescendants' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(new Node<int>[] { tree }, default(Node<int>)));
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(new Node<int>[] { tree }, default(Node<int>), EqualityComparer<Node<int>>.Default));
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(tree, default(Node<int>)).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(tree, default(Node<int>), EqualityComparer<Node<int>>.Default).ToArray());
        }

        [Fact]
        public void GetDescendants_ByKey_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();
            
            // Assert that 'GetDescendants' throws an 'ArgumentNullException' when the node is
            // null.
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetDescendants((IEnumerable<Node<int>>)null, default(Node<int>)));
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetDescendants((IEnumerable<Node<int>>)null, default(Node<int>), EqualityComparer<Node<int>>.Default));
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetDescendants((Node<int>)null, default(Node<int>)).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetDescendants((Node<int>)null, default(Node<int>), EqualityComparer<Node<int>>.Default).ToArray());
        }

        [Fact]
        public void GetDescendants_ByKey_NullKey_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDescendants' throws an 'ArgumentNullException' when the predicate 
            // is null.
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetDescendants(new Node<int>[] { tree }, (Node<int>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetDescendants(new Node<int>[] { tree }, (Node<int>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetDescendants(tree, (Node<int>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "key",
                () => walker.GetDescendants(tree, (Node<int>)null).ToArray());
        }

        [Fact]
        public void GetDescendants_ByKey_NullComparer()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            foreach (Node<int> key in walker.PreOrderTraversal(tree))
            {
                IEnumerable<Node<int>> result = walker.GetDescendants(tree, key);
                Assert.Equal(1, result.Count());
                Assert.Equal(key, result.First());
            }
        }

        [Fact]
        public void GetDescendants_ByKey_NonNullComparer()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            foreach (Node<int> key in walker.PreOrderTraversal(tree))
            {
                IEnumerable<Node<int>> result = walker.GetDescendants(tree, key, new NodeComparer<int>());
                Assert.Equal(1, result.Count());
                Assert.Equal(key, result.First());
            }
        }
    }
}
