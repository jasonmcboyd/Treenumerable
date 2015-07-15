using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void TryGetChildAt_ValidIndex_ReturnsTrue()
        {
            // Get a valid tree.
            var tree = 
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Try and get a child at a valid index.
            Node<int> node;
            bool result = walker.TryGetChildAt(tree, 0, out node);

            // Assert.
            Assert.Equal(1, node.Value);
            Assert.True(result);
        }

        [Fact]
        public void TryGetChildAt_InvalidIndex_ReturnsFalse()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Try and get a child at an invalid index.
            Node<int> node;
            bool result = walker.TryGetChildAt(tree, 1, out node);

            // Assert.
            Assert.Null(node);
            Assert.False(result);
        }
    }
}
