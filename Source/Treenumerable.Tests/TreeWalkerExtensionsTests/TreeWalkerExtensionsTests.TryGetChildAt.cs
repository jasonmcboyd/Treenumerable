using Moq;
using System.Collections.Generic;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void TryGetChildAt_ValidIndex_GetChildrenReturnsIEnumerable_ReturnsTrue()
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
        public void TryGetChildAt_InvalidIndex_GetChildrenReturnsIEnumerable_ReturnsFalse()
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

        [Fact]
        public void TryGetChildAt_NoChildren_GetChildrenReturnsIEnumerable_ReturnsFalse()
        {
            // Get a valid tree.
            var tree = Node.Create(0);

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Try and get a child at an invalid index.
            Node<int> node;
            bool result = walker.TryGetChildAt(tree, 0, out node);

            // Assert.
            Assert.Null(node);
            Assert.False(result);
        }

        [Fact]
        public void TryGetChildAt_GetChildrenReturnsIEnumerable_GetEnumeratorCalled()
        {
            Mock<IEnumerable<Node<int>>> mockEnumerable = new Mock<IEnumerable<Node<int>>>();
            Mock<ITreeWalker<Node<int>>> mockWalker = new Mock<ITreeWalker<Node<int>>>();

            mockEnumerable
            .Setup(x => x.GetEnumerator())
            .Returns(Mock.Of<IEnumerator<Node<int>>>());

            mockWalker
            .Setup(x => x.GetChildren(It.IsAny<Node<int>>()))
            .Returns(mockEnumerable.Object);

            Node<int> blah;
            TreeWalkerExtensions
            .TryGetChildAt(
                mockWalker.Object,
                default(Node<int>),
                0,
                out blah);

            mockEnumerable.Verify(x => x.GetEnumerator(), Times.Once);
        }

        [Fact]
        public void TryGetChildAt_ValidIndex_GetChildrenReturnsIList_ReturnsTrue()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>()
            {
                ReturnChildrenAsList = true
            };

            // Try and get a child at a valid index.
            Node<int> node;
            bool result = walker.TryGetChildAt(tree, 0, out node);

            // Assert.
            Assert.Equal(1, node.Value);
            Assert.True(result);
        }

        [Fact]
        public void TryGetChildAt_InvalidIndex_GetChildrenReturnsIList_ReturnsFalse()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>()
            {
                ReturnChildrenAsList = true
            };

            // Try and get a child at an invalid index.
            Node<int> node;
            bool result = walker.TryGetChildAt(tree, 1, out node);

            // Assert.
            Assert.Null(node);
            Assert.False(result);
        }

        [Fact]
        public void TryGetChildAt_NoChildren_GetChildrenReturnsIList_ReturnsFalse()
        {
            // Get a valid tree.
            var tree = Node.Create(0);

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>()
            {
                ReturnChildrenAsList = true
            };

            // Try and get a child at an invalid index.
            Node<int> node;
            bool result = walker.TryGetChildAt(tree, 0, out node);

            // Assert.
            Assert.Null(node);
            Assert.False(result);
        }

        [Fact]
        public void TryGetChildAt_GetChildrenReturnsIList_GetEnumeratorNotCalled()
        {
            Mock<IList<Node<int>>> mockList = new Mock<IList<Node<int>>>();
            Mock<ITreeWalker<Node<int>>> mockWalker = new Mock<ITreeWalker<Node<int>>>();

            mockWalker
            .Setup(x => x.GetChildren(It.IsAny<Node<int>>()))
            .Returns(mockList.Object);

            Node<int> blah;
            TreeWalkerExtensions
            .TryGetChildAt(
                mockWalker.Object,
                default(Node<int>),
                0,
                out blah);

            mockList.Verify(x => x.GetEnumerator(), Times.Never);
            mockList.VerifyGet(x => x.Count, Times.Once);
        }
    }
}
