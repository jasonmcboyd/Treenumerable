using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetHeightTests
    {
        [Fact]
        public void GetHeight_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetHeight' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetHeight(tree));
        }

        [Fact]
        public void GetHeight_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetHeight' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetHeight(null));
        }

        [Fact]
        public void GetHeight()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetHeight' returns the correct elements.
            Assert.Equal(
                3,
                walker.GetHeight(tree));
            Assert.Equal(
                1,
                walker.GetHeight(tree[0]));
            Assert.Equal(
                0,
                walker.GetHeight(tree[0][0]));
            Assert.Equal(
                0,
                walker.GetHeight(tree[0][1]));
            Assert.Equal(
                2,
                walker.GetHeight(tree[1]));
            Assert.Equal(
                1,
                walker.GetHeight(tree[1][0]));
            Assert.Equal(
                0,
                walker.GetHeight(tree[1][0][0]));
        }
    }
}
