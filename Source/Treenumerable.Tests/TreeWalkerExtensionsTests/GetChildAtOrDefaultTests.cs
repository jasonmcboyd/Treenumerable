using Treenumerable.Tests.TreeBuilder;
using Xunit;
using System.Linq;
using System;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetChildAtOrDefaultTests
    {
        [Fact]
        public void GetChildAtOrDefault_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Assert.Throws<ArgumentNullException>("walker", () => walker.GetChildAtOrDefault(tree, 0));
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetChildAtOrDefault(EnumerableEx.Return(tree), 0));
        }

        [Fact]
        public void GetChildAtOrDefault_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentNullException>("node", () => walker.GetChildAtOrDefault((Node<int>)null, 0));
            Assert.Throws<ArgumentNullException>("nodes", () => walker.GetChildAtOrDefault((Node<int>[])null, 0));
        }

        [Fact]
        public void GetChildAtOrDefault_IndexLessThanZero_ThrowArgumentOutOfRangeException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentOutOfRangeException>("index", () => walker.GetChildAtOrDefault(tree, -1));
            Assert.Throws<ArgumentOutOfRangeException>("index", () => walker.GetChildAtOrDefault(EnumerableEx.Return(tree), -1));
        }

        [Fact]
        public void GetChildAtOrDefault_ValidIndex_ReturnsNode()
        {
            // Get a valid tree.
            var tree = 
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(1, walker.GetChildAtOrDefault(tree, 0).Value);
            Assert.Equal(
                EnumerableEx.Return(1),
                walker.GetChildAtOrDefault(EnumerableEx.Return(tree), 0).Select(x => x.Value));
        }

        [Fact]
        public void GetChildAtOrDefault_InvalidIndex_ReturnsNull()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Null(walker.GetChildAtOrDefault(tree, 1));
            Assert.Equal(
                EnumerableEx.Return<Node<int>>(null),
                walker.GetChildAtOrDefault(EnumerableEx.Return(tree), 1));
        }
    }
}
