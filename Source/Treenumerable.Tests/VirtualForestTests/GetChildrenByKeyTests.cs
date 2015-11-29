using Moq;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.VirtualForestTests
{
    public class GetChildrenByKeyTests
    {
        
        [Fact]
        public void ChildrenByKey_PropertyComparerIsInvoked()
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

            // Execute Children.
            vt.Children(key: key).Roots.ToArray();

            // Verify that the VirtualForest's comparer was used.
            mockComparer.Verify(x => x.Equals(key, It.IsAny<Node<int>>()), Times.AtLeastOnce);
        }

        [Fact]
        public void ChildrenByKey_ArgumentComparerIsInvoked()
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

            // Execute the Children.
            vt.Children(key, mockComparer.Object).Roots.ToArray();

            // Verify that the comparer argument was used.
            mockComparer.Verify(x => x.Equals(key, It.IsAny<Node<int>>()), Times.AtLeastOnce);
        }
    }
}
