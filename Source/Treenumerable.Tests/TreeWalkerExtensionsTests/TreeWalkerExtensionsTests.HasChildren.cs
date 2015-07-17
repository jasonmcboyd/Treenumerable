using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void HasChildren_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'HasChildren' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.HasChildren(tree));
        }

        [Fact]
        public void HasChildren_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'HasChildren' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.HasChildren(null));
        }

        [Fact]
        public void HasChildren()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'HasChildren' returns the correct value.
            Assert.Equal(true, walker.HasChildren(tree));
            Assert.Equal(true, walker.HasChildren(tree[0]));
            Assert.Equal(false, walker.HasChildren(tree[0][0]));
            Assert.Equal(false, walker.HasChildren(tree[0][1]));
            Assert.Equal(true, walker.HasChildren(tree[1]));
            Assert.Equal(true, walker.HasChildren(tree[1][0]));
            Assert.Equal(false, walker.HasChildren(tree[1][0][0]));
        }
    }
}
