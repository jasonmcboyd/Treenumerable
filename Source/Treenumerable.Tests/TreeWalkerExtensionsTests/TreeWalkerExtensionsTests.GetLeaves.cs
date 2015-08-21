using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {      
        [Fact]
        public void GetLeaves_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetLeaves' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetLeaves(tree).ToArray());
        }

        [Fact]
        public void GetLeaves_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetLeaves' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetLeaves(null).ToArray());
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { 2, 3, 6 })]
        [InlineData(new int[] { 0 }, new int[] { 2, 3 })]
        [InlineData(new int[] { 0, 0 }, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 3 })]
        [InlineData(new int[] { 1 }, new int[] { 6 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 6 })]
        [InlineData(new int[] { 1, 0, 0 }, new int[] { 6 })]
        public void GetLeaves(int[] testPath, int[] expected)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            var node = tree;
            foreach (int i in testPath)
            {
                node = walker.GetChildAt(node, i);
            }
            
            Assert.Equal(
                expected,
                walker.GetLeaves(node).Select(x => x.Value));
        }
    }
}
