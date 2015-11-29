using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class GetAncestorsAndSelfTests
    {
        [Fact]
        public void GetAncestorsAndSelf_NullTreeWalker_ThrowsArgumentNullException()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1));
            
            // Get a null ITreeWalker.
            NodeWalker<int> walker = null;

            Assert.Throws<ArgumentNullException>(
                "walker", 
                () => walker.GetAncestorsAndSelf(tree).ToArray());
        }

        [Fact]
        public void GetAncestorsAndSelf_NullNode_ThrowsArgumentNullException()
        {
            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Assert.Throws<ArgumentNullException>(
                "node", 
                () => walker.GetAncestorsAndSelf(null).ToArray());
        }

        [Fact]
        public void GetAncestorsAndSelf_SingleNodeInTree_NodeReturned()
        {
            // Get tree with a single node.
            var tree = Node.Create(0);

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert.
            Assert.Equal(
                EnumerableEx.Return(tree).ToArray(), 
                walker.GetAncestorsAndSelf(tree).ToArray());
        }

        [Fact]
        public void GetAncestorsAndSelf_CorrectNodesReturned()
        {
            // Get a valid tree.
            var tree =
                Node.Create(0).AddChildren(
                    Node.Create(1).AddChildren(
                        Node.Create(2)));

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            Node<int> node = tree[0][0];
            // Assert.
            Assert.Equal(
                Enumerable.Concat(new Node<int>[] { node }, walker.GetAncestors(node)).ToArray(),
                walker.GetAncestorsAndSelf(node).ToArray());
        }
    }
}
