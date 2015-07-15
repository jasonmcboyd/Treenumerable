using Treenumerable.Tests.TreeBuilder;
using Xunit;
using System.Linq;
using System;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetChildAt_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));
            
            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Assert.Throws<ArgumentNullException>("walker", () => walker.GetChildAt(tree, 0));
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetChildAt(EnumerableEx.Return(tree), 0).ToArray());
        }

        [Fact]
        public void GetChildAt_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentNullException>("node", () => walker.GetChildAt((Node<int>)null, 0));
            Assert.Throws<ArgumentNullException>("nodes", () => walker.GetChildAt((Node<int>[])null, 0).ToArray());
        }

        [Fact]
        public void GetChildAt_IndexLessThanZero_ThrowArgumentOutOfRangeException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentOutOfRangeException>("index", () => walker.GetChildAt(tree, -1));
            Assert.Throws<ArgumentOutOfRangeException>("index", () => walker.GetChildAt(EnumerableEx.Return(tree), -1).ToArray());
        }

        [Fact]
        public void GetChildAt_ValidIndex_ReturnsNode()
        {
            // Get a valid tree.
            var tree = 
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(1, walker.GetChildAt(tree, 0).Value);
            Assert.Equal(
                EnumerableEx.Return(1),
                walker.GetChildAt(EnumerableEx.Return(tree), 0).Select(x => x.Value));
        }

        [Fact]
        public void GetChildAt_InvalidIndex_ThrowsArgumentOutOfRangeException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Throws<ArgumentOutOfRangeException>("index", () => walker.GetChildAt(tree, 1));
        }

        [Fact]
        public void GetChildAt_OfEnumerable_InvalidIndex_ReturnsEmptyArray()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(
                Enumerable.Empty<Node<int>>(),
                walker.GetChildAt(EnumerableEx.Return(tree), 1).ToArray());
        }
    }
}
