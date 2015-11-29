using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetDegreeTests
    {
        [Fact]
        public void GetDegree_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetDegree' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetDegree(tree));
        }

        [Fact]
        public void GetDegree_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDegree' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetDegree(null));
        }

        [Fact]
        public void GetDegree()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'GetDegree' returns the number of children
            // that the node has.
            foreach (Node<int> node in walker.PreOrderTraversal(tree))
            {
                Assert.Equal(node.Children.Count, walker.GetDegree(node));
            }
        }
    }
}
