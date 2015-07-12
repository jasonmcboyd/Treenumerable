using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Treenumerable;
using Treenumerable.Tests.TreeBuilder;

namespace Treenumerable.Tests
{
    public class EnumerableOfVirtualTreeExtensionsTests
    {
        [Theory]
        [InlineData(0, new int[] { 0, 0 })]
        [InlineData(1, new int[] { 1, 1 })]
        [InlineData(2, new int[] { 2, 2 })]
        [InlineData(3, new int[] { })]
        public void GetChildAt(int index, int[] expected)
        {
            IEnumerable<VirtualTree<Node<int>>> nums =
                Enumerable
                .Range(0, 2)
                .Select(x =>
                    VirtualTree
                    .Create(
                        new NodeWalker<int>(),
                        Node
                        .Create(x)
                        .AddChildren(
                            Enumerable
                            .Range(0, 3)
                            .Select(y => Node.Create(y))
                            .ToArray())));

            Assert.Equal(expected, nums.GetChildAt(index).Unwrap().Select(x => x.Value).ToArray());
        }

        [Fact]
        public void GetChildAt_NullSource_ArgumentNullExceptionThrown()
        {
            Assert.Throws<ArgumentNullException>(
                "virtualTrees",
                () => 
                    EnumerableOfVirtualTreeExtensions
                    .GetChildAt<int>(null, 0)
                    .ToArray()); 
        }

        [Fact]
        public void GetChildAt_IndexNegative_ArgumentOutOfRangeExceptionThrown()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                "index",
                () => 
                    EnumerableOfVirtualTreeExtensions
                    .GetChildAt<int>(Enumerable.Empty<VirtualTree<int>>(), -1)
                    .ToArray());
        }
    }
}
