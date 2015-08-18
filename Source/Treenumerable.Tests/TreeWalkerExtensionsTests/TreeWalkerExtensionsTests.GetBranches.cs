using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetBranches_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));
            
            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Assert.Throws<ArgumentNullException>(
                "walker", 
                () => walker.GetBranches(tree).ToArray());
        }

        [Fact]
        public void GetBranches_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentNullException>(
                "node", 
                () => walker.GetBranches(null).ToArray());
        }

        [Fact]
        public void GetBranches_SingleNodeInTree()
        {
            // Get tree with a single node.
            var tree = Node.Create(0);

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(
                EnumerableEx.Return(EnumerableEx.Return(tree).ToArray()).ToArray(), 
                walker.GetBranches(tree).Select(x => x.ToArray()).ToArray());
        }

        [Fact]
        public void GetBranches_SingleBranch()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1).AddChildren(
                        Node.Create(2)));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(
                EnumerableEx.Return(walker.PreOrderTraversal(tree).ToArray()).ToArray(),
                walker.GetBranches(tree).Select(x => x.ToArray()).ToArray());
        }

        [Fact]
        public void GetBranches_MultipleBranches()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(
                walker
                .GetLeaves(tree)
                .Select(x => 
                    EnumerableEx
                    .Return(x)
                    .Concat(walker.GetAncestors(x))
                    .Reverse()
                    .ToArray())
                .ToArray(),
                walker.GetBranches(tree).Select(x => x.ToArray()).ToArray());
        }
    }
}
