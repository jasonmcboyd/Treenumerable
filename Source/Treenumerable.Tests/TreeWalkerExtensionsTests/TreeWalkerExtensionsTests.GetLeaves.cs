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

        [Fact]
        public void GetLeaves()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 2, 3, 6 };
            int[] node1ExpectedResult = new int[] { 2, 3 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 6 };
            int[] node5ExpectedResult = new int[] { 6 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'GetLeaves' returns the correct elements.
            Assert.Equal(
                node0ExpectedResult,
                walker.GetLeaves(tree).Select(x => x.Value));
            Assert.Equal(
                node1ExpectedResult,
                walker.GetLeaves(tree[0]).Select(x => x.Value));
            Assert.Equal(
                node2ExpectedResult,
                walker.GetLeaves(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                node3ExpectedResult,
                walker.GetLeaves(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                node4ExpectedResult,
                walker.GetLeaves(tree[1]).Select(x => x.Value));
            Assert.Equal(
                node5ExpectedResult,
                walker.GetLeaves(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                node6ExpectedResult,
                walker.GetLeaves(tree[1][0][0]).Select(x => x.Value));
        }
    }
}
