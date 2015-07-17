using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {      
        [Fact]
        public void GetLevel_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetLevel' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetLevel(tree, 0).ToArray());
        }

        [Fact]
        public void GetLevel_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetLevel' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetLevel(null, 0).ToArray());
        }

        [Fact]
        public void GetLevel_NegativeDepth_ArgumentExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetLevel' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentException>("depth", () => walker.GetLevel(tree, -1).ToArray());
        }

        [Fact]
        public void GetLevel()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetLevel' returns the correct elements.
            Assert.Equal(
                new int[] { 0 },
                walker.GetLevel(tree, 0).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1, 4 },
                walker.GetLevel(tree, 1).Select(x => x.Value));
            Assert.Equal(
                new int[] { 2, 3, 5 },
                walker.GetLevel(tree, 2).Select(x => x.Value));
            Assert.Equal(
                new int[] { 6 },
                walker.GetLevel(tree, 3).Select(x => x.Value));
        }
    }
}
