using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void TryGetParent_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Node<int> parent = null;

            Assert.Throws<ArgumentNullException>("walker", () => walker.TryGetParent(tree, out parent));
        }

        [Fact]
        public void TryGetParent_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Node<int> parent = null;

            Assert.Throws<ArgumentNullException>("node", () => walker.TryGetParent(null, out parent));
        }

        [Fact]
        public void TryGetParent_NodeHasParent_ReturnsNode()
        {
            // Get a valid tree.
            var tree = 
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Node<int> parent = null;
            bool result = walker.TryGetParent(tree.Children[0], out parent);

            Assert.True(result);
            Assert.Equal(0, parent.Value);
        }

        [Fact]
        public void TryGetParent_NodeDoesNotHaveParent_ReturnsNull()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Node<int> parent = null;
            bool result = walker.TryGetParent(tree, out parent);

            Assert.False(result);
            Assert.Null(parent);
        }
    }
}
