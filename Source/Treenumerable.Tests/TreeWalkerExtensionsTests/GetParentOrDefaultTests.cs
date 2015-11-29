using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetParentOrDefaultTests
    {
        [Fact]
        public void GetParentOrDefault_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Assert.Throws<ArgumentNullException>("walker", () => walker.GetParentOrDefault(tree));
        }

        [Fact]
        public void GetParentOrDefault_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentNullException>("node", () => walker.GetParentOrDefault(null));
        }

        [Fact]
        public void GetParentOrDefault_NodeHasParent_ReturnsNode()
        {
            // Get a valid tree.
            var tree = 
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Node<int> parent = walker.GetParentOrDefault(tree[0]);

            Assert.Equal(0, parent.Value);
        }

        [Fact]
        public void GetParentOrDefault_NodeDoesNotHaveParent_ReturnsNull()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Null(walker.GetParentOrDefault(tree));
        }
    }
}
