using Moq;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.VirtualForestTests
{
    public class GetDescendantsByKeyTests
    {
        // TODO: fix this.
        [Fact]
        [Trait("Skip", "true")]
        public void Descendants_ByKey_PropetyComparerIsInvoked()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a mock IComparer.
            Mock<IEqualityComparer<Node<int>>> mockComparer = new Mock<IEqualityComparer<Node<int>>>();
            mockComparer
                .Setup(mock => mock.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()))
                .Returns(true);

            // Create a VirtualForest.
            IVirtualForest<Node<int>> vt = VirtualForest.New(new NodeWalker<int>(), mockComparer.Object, tree);

            // Create a key to use for comparison.  Any key is fine.
            Node<int> key = new Node<int>(0);

            // Execute Descendants.
            vt.Descendants(key: key).Roots.ToArray();

            // Verify that the VirtualForest's comparer was used.
            //mockComparer.Verify(x => x.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()), Times.Exactly(vt.GetDegree()));
        }

        // TODO: fix this.
        [Fact]
        [Trait("Skip", "true")]
        public void Descendants_ByKey_ArgumentComparerIsInvoked()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a mock IComparer.
            Mock<IEqualityComparer<Node<int>>> mockComparer = new Mock<IEqualityComparer<Node<int>>>();
            mockComparer
                .Setup(mock => mock.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()))
                .Returns(true);

            // Create a VirtualForest.
            IVirtualForest<Node<int>> vt = VirtualForest.New(new NodeWalker<int>(), tree);

            // Create a key to use for comparison.  Any key is fine.
            Node<int> key = new Node<int>(0);

            // Execute Descendants.
            vt.Descendants(key, mockComparer.Object).Roots.ToArray();

            // Verify that the VirtualForest's comparer was used.
            //mockComparer.Verify(x => x.Equals(It.IsAny<Node<int>>(), It.IsAny<Node<int>>()), Times.Exactly(vt.GetDegree()));
        }
    }
}
