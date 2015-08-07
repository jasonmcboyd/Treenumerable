using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetPrecedingSiblings_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetPrecedingSiblings' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetPrecedingSiblings(tree).ToArray());
        }

        [Fact]
        public void GetPrecedingSiblings_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetPrecedingSiblings' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetPrecedingSiblings(null).ToArray());
        }

        [Fact]
        public void GetPrecedingSiblings()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetPrecedingSiblings' returns the correct 
            // elements.
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 2 },
                walker.GetPrecedingSiblings(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1 },
                walker.GetPrecedingSiblings(tree[1]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[1][0][0]).Select(x => x.Value));
        }
    }
}
