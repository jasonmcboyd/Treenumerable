using System;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class HasParentTests
    {
        [Fact]
        public void HasParent_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Assert.Throws<ArgumentNullException>("walker", () => walker.HasParent(tree));
        }

        [Fact]
        public void HasParent_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentNullException>("node", () => walker.HasParent(null));
        }

        [Fact]
        public void HasParent_NodeHasParent_ReturnsTrue()
        {
            // Get a valid tree.
            var tree = 
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.True(walker.HasParent(tree[0]));
        }

        [Fact]
        public void HasParent_NodeDoesNotHaveParent_ReturnsFalse()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.False(walker.HasParent(tree));
        }
    }
}
