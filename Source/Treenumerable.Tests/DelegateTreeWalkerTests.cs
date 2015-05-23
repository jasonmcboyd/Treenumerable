using System;
using Xunit;

namespace Treenumerable.Tests
{
    public class DelegateTreeWalkerTests
    {
        [Fact]
        public void Instantiate_NullGetParentFunc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                {
                    new DelegateTreeWalker<int>(null, i => new int[] { i });
                });
        }

        [Fact]
        public void Instantiate_NullGetChildrenFunc_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                new DelegateTreeWalker<int>(i => ParentNode.Create(i), null);
            });
        }
    }
}
