using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetRootTests
    {
        [Fact]
        public void GetRoot_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetRoot' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetRoot(tree));
        }

        [Fact]
        public void GetRoot_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetRoot' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetRoot(null));
        }

        [Fact]
        public void GetRoot()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'GetRoot' returns the root of the tree.
            foreach (Node<int> node in walker.PreOrderTraversal(tree))
            {
                Assert.Equal(tree.Value, walker.GetRoot(node).Value);
            }
        }
    }
}
