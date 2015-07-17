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

        [Fact]
        public void GetSiblings()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetSiblings' returns the correct 
            // elements.
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetSiblings(tree).Select(x => x.Value));
            Assert.Equal(
                new int[] { 4 },
                walker.GetSiblings(tree[0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 3 },
                walker.GetSiblings(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 2 },
                walker.GetSiblings(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1 },
                walker.GetSiblings(tree[1]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetSiblings(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetSiblings(tree[1][0][0]).Select(x => x.Value));
        }
    }
}
