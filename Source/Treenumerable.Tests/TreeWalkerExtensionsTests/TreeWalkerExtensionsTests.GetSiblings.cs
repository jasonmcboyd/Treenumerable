using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetSiblings_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetSiblings' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetSiblings(tree).ToArray());
        }

        [Fact]
        public void GetSiblings_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetSiblings' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetSiblings(null).ToArray());
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 0 }, new int[] { 4 })]
        [InlineData(new int[] { 0, 0 }, new int[] { 3 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 2 })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 1, 0 }, new int[] { })]
        [InlineData(new int[] { 1, 0, 0 }, new int[] { })]
        public void GetSiblings(int[] path, int[] expectedResult)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            foreach (int i in path)
            {
                tree = tree[i];
            }

            // For each node in the tree assert that 'GetSiblings' returns the correct 
            // elements.
            Assert.Equal(
                expectedResult,
                walker.GetSiblings(tree).Select(x => x.Value));
        }
    }
}
