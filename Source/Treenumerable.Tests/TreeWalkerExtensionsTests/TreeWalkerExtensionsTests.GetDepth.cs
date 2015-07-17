using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetDepth_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetDepth' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetDepth(tree));
        }

        [Fact]
        public void GetDepth_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDepth' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetDepth(null));
        }

        [Fact]
        public void GetDepth()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetDepth' returns the correct elements.
            Assert.Equal(
                0,
                walker.GetDepth(tree));
            Assert.Equal(
                1,
                walker.GetDepth(tree[0]));
            Assert.Equal(
                2,
                walker.GetDepth(tree[0][0]));
            Assert.Equal(
                2,
                walker.GetDepth(tree[0][1]));
            Assert.Equal(
                1,
                walker.GetDepth(tree[1]));
            Assert.Equal(
                2,
                walker.GetDepth(tree[1][0]));
            Assert.Equal(
                3,
                walker.GetDepth(tree[1][0][0]));
        }
    }
}
