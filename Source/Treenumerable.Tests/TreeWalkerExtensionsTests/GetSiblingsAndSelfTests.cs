using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetSiblingsAndSelfTests
    {
        [Fact]
        public void GetSiblingsAndSelf_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetSiblingsAndSelf' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetSiblingsAndSelf(tree).ToArray());
        }

        [Fact]
        public void GetSiblingsAndSelf_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetSiblingsAndSelf' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetSiblingsAndSelf(null).ToArray());
        }

        [Theory]
        [InlineData(new int[] { }, new int[] { 0 })]
        [InlineData(new int[] { 0 }, new int[] { 1, 4 })]
        [InlineData(new int[] { 0, 0 }, new int[] { 2, 3 })]
        [InlineData(new int[] { 0, 1 }, new int[] { 2, 3 })]
        [InlineData(new int[] { 1 }, new int[] { 1, 4 })]
        [InlineData(new int[] { 1, 0 }, new int[] { 5 })]
        [InlineData(new int[] { 1, 0, 0 }, new int[] { 6 })]
        public void GetSiblingsAndSelf(int[] path, int[] expectedResult)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            foreach (int i in path)
            {
                tree = tree[i];
            }

            // For each node in the tree assert that 'GetSiblingsAndSelf' returns the correct 
            // elements.
            Assert.Equal(
                expectedResult,
                walker.GetSiblingsAndSelf(tree).Select(x => x.Value));
        }
    }
}
