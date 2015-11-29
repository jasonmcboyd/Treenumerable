using Moq;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.VirtualTreeTests
{
    public class GetDescendantsByKey
    {
        [Fact]
        public void GetDescendants_ByKey_PropetyComparerIsInvoked()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a mock IComparer.
            Mock<IEqualityComparer<Node<int>>> mockComparer = new Mock<IEqualityComparer<Node<int>>>();
            mockComparer
                .Setup(mock => mock.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()))
                .Returns(true);

            // Create a VirtualTree.
            VirtualTree<Node<int>> vt = VirtualTree.New(new NodeWalker<int>(), tree, mockComparer.Object);

            // Create a key to use for comparison.  Any key is fine.
            Node<int> key = new Node<int>(0);

            // Execute GetDescendants.
            vt.GetDescendants(key: key).ToArray();

            // Verify that the VirtualTree's comparer was used.
            mockComparer.Verify(x => x.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()), Times.Exactly(vt.GetDegree()));
        }

        [Fact]
        public void GetDescendants_ByKey_ArgumentComparerIsInvoked()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a mock IComparer.
            Mock<IEqualityComparer<Node<int>>> mockComparer = new Mock<IEqualityComparer<Node<int>>>();
            mockComparer
                .Setup(mock => mock.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()))
                .Returns(true);

            // Create a VirtualTree.
            VirtualTree<Node<int>> vt = VirtualTree.New(new NodeWalker<int>(), tree);

            // Create a key to use for comparison.  Any key is fine.
            Node<int> key = new Node<int>(0);

            // Execute GetDescendants.
            vt.GetDescendants(key, mockComparer.Object).ToArray();

            // Verify that the VirtualTree's comparer was used.
            mockComparer.Verify(x => x.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()), Times.Exactly(vt.GetDegree()));
        }
    }
}
