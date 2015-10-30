using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetPrecedingSiblingsAndSelf_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetPrecedingSiblingsAndSelf' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetPrecedingSiblingsAndSelf(tree).ToArray());
        }

        [Fact]
        public void GetPrecedingSiblingsAndSelf_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetPrecedingSiblingsAndSelf' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetPrecedingSiblingsAndSelf(null).ToArray());
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { 0 })]
        [InlineData(new int[] { 0 }, new int[] { 1 })]
        [InlineData(new int[] { 0, 0 }, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 2, 3 })]
        [InlineData(new int[] { 1 }, new int[] { 1, 4 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 5 })]
        [InlineData(new int[] { 1, 0, 0 }, new int[] { 6 })]
        public void GetPrecedingSiblingsAndSelf(int[] path, int[] expectedResult)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            foreach (int i in path)
            {
                tree = tree[i];
            }

            // For each node in the tree assert that 'GetPrecedingSiblingsAndSelf' returns the
            // correct elements.
            Assert.Equal(
                expectedResult,
                walker.GetPrecedingSiblingsAndSelf(tree).Select(x => x.Value));
        }
    }
}
