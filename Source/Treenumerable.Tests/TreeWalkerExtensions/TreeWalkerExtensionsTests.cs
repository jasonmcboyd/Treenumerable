using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public class TreeWalkerExtensionsTests
    {
        private Node<int> GetTree()
        {
            return
                Node.Create<int>(0).AddChildren(
                    Node.Create(1).AddChildren(
                        Node.Create(2),
                        Node.Create(3)),
                    Node.Create(4).AddChildren(
                        Node.Create(5).AddChildren(
                            Node.Create(6))));
        }

        #region GetAncestors

        [Fact]
        public void GetAncestors_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetAncestors' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetAncestors(tree).ToArray());
        }

        [Fact]
        public void GetAncestors_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetAncestors' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetAncestors(null).ToArray());
        }

        [Fact]
        public void GetAncestors()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetAncestors' returns the correct elements.
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetAncestors(tree).Select(x => x.Value));
            Assert.Equal(
                new int[] { 0 },
                walker.GetAncestors(tree[0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1, 0 },
                walker.GetAncestors(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1, 0 },
                walker.GetAncestors(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 0 },
                walker.GetAncestors(tree[1]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 4, 0 },
                walker.GetAncestors(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 5, 4, 0 },
                walker.GetAncestors(tree[1][0][0]).Select(x => x.Value));
        }

        #endregion

        #region GetDegree

        [Fact]
        public void GetDegree_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetDegree' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetDegree(tree));
        }

        [Fact]
        public void GetDegree_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDegree' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetDegree(null));
        }

        [Fact]
        public void GetDegree()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'GetDegree' returns the number of children
            // that the node has.
            foreach (Node<int> node in walker.PreOrderTraversal(tree, true))
            {
                Assert.Equal(node.Children.Count, walker.GetDegree(node));
            }
        }

        #endregion

        #region GetDepth

        [Fact]
        public void GetDepth_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetDepth' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetDepth(tree));
        }

        [Fact]
        public void GetDepth_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDepth' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetDepth(null));
        }

        [Fact]
        public void GetDepth()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetDepth' returns the correct elements.
            Assert.Equal(
                0,
                walker.GetDepth(tree));
            Assert.Equal(
                1,
                walker.GetDepth(tree[0]));
            Assert.Equal(
                2,
                walker.GetDepth(tree[0][0]));
            Assert.Equal(
                2,
                walker.GetDepth(tree[0][1]));
            Assert.Equal(
                1,
                walker.GetDepth(tree[1]));
            Assert.Equal(
                2,
                walker.GetDepth(tree[1][0]));
            Assert.Equal(
                3,
                walker.GetDepth(tree[1][0][0]));
        }

        #endregion

        #region GetHeight

        [Fact]
        public void GetHeight_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetHeight' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetHeight(tree));
        }

        [Fact]
        public void GetHeight_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetHeight' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetHeight(null));
        }

        [Fact]
        public void GetHeight()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetHeight' returns the correct elements.
            Assert.Equal(
                3,
                walker.GetHeight(tree));
            Assert.Equal(
                1,
                walker.GetHeight(tree[0]));
            Assert.Equal(
                0,
                walker.GetHeight(tree[0][0]));
            Assert.Equal(
                0,
                walker.GetHeight(tree[0][1]));
            Assert.Equal(
                2,
                walker.GetHeight(tree[1]));
            Assert.Equal(
                1,
                walker.GetHeight(tree[1][0]));
            Assert.Equal(
                0,
                walker.GetHeight(tree[1][0][0]));
        }

        #endregion

        #region GetLeaves

        [Fact]
        public void GetLeaves_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetLeaves' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetLeaves(tree).ToArray());
        }

        [Fact]
        public void GetLeaves_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetLeaves' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetLeaves(null).ToArray());
        }

        [Fact]
        public void GetLeaves()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 2, 3, 6 };
            int[] node1ExpectedResult = new int[] { 2, 3 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 6 };
            int[] node5ExpectedResult = new int[] { 6 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'GetLeaves' returns the correct elements.
            Assert.Equal(
                node0ExpectedResult,
                walker.GetLeaves(tree).Select(x => x.Value));
            Assert.Equal(
                node1ExpectedResult,
                walker.GetLeaves(tree[0]).Select(x => x.Value));
            Assert.Equal(
                node2ExpectedResult,
                walker.GetLeaves(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                node3ExpectedResult,
                walker.GetLeaves(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                node4ExpectedResult,
                walker.GetLeaves(tree[1]).Select(x => x.Value));
            Assert.Equal(
                node5ExpectedResult,
                walker.GetLeaves(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                node6ExpectedResult,
                walker.GetLeaves(tree[1][0][0]).Select(x => x.Value));
        }

        #endregion

        #region GetLevel

        [Fact]
        public void GetLevel_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetLevel' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetLevel(tree, 0).ToArray());
        }

        [Fact]
        public void GetLevel_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetLevel' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetLevel(null, 0).ToArray());
        }

        [Fact]
        public void GetLevel_NegativeDepth_ArgumentExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetLevel' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentException>("depth", () => walker.GetLevel(tree, -1).ToArray());
        }

        [Fact]
        public void GetLevel()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetLevel' returns the correct elements.
            Assert.Equal(
                new int[] { 0 },
                walker.GetLevel(tree, 0).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1, 4 },
                walker.GetLevel(tree, 1).Select(x => x.Value));
            Assert.Equal(
                new int[] { 2, 3, 5 },
                walker.GetLevel(tree, 2).Select(x => x.Value));
            Assert.Equal(
                new int[] { 6 },
                walker.GetLevel(tree, 3).Select(x => x.Value));
        }

        #endregion

        #region GetParent

        [Fact]
        public void GetParent_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetParent' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetParent(tree));
        }

        [Fact]
        public void GetParent_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetParent' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetParent(null));
        }

        [Fact]
        public void GetParent()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'GetParent' returns the node's parent.
            foreach (Node<int> node in walker.PreOrderTraversal(tree, true))
            {
                Assert.Equal(walker.GetParentNode(node).Value, walker.GetParent(node));
            }
        }

        #endregion

        #region GetRoot

        [Fact]
        public void GetRoot_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetRoot' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetRoot(tree));
        }

        [Fact]
        public void GetRoot_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetRoot' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetRoot(null));
        }

        [Fact]
        public void GetRoot()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'GetRoot' returns the root of the tree.
            foreach (Node<int> node in walker.PreOrderTraversal(tree, true))
            {
                Assert.Equal(tree.Value, walker.GetRoot(node).Value);
            }
        }

        #endregion

        #region GetPrecedingSiblings

        [Fact]
        public void GetPrecedingSiblings_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetPrecedingSiblings' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetPrecedingSiblings(tree).ToArray());
        }

        [Fact]
        public void GetPrecedingSiblings_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetPrecedingSiblings' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetPrecedingSiblings(null).ToArray());
        }

        [Fact]
        public void GetPrecedingSiblings()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetPrecedingSiblings' returns the correct 
            // elements.
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 2 },
                walker.GetPrecedingSiblings(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1 },
                walker.GetPrecedingSiblings(tree[1]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetPrecedingSiblings(tree[1][0][0]).Select(x => x.Value));
        }

        #endregion

        #region GetFollowingSiblings

        [Fact]
        public void GetFollowingSiblings_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetFollowingSiblings' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetFollowingSiblings(tree).ToArray());
        }

        [Fact]
        public void GetFollowingSiblings_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetFollowingSiblings' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetFollowingSiblings(null).ToArray());
        }

        [Fact]
        public void GetFollowingSiblings()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetFollowingSiblings' returns the correct 
            // elements.
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetFollowingSiblings(tree).Select(x => x.Value));
            Assert.Equal(
                new int[] { 4 },
                walker.GetFollowingSiblings(tree[0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 3 },
                walker.GetFollowingSiblings(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetFollowingSiblings(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetFollowingSiblings(tree[1]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetFollowingSiblings(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetFollowingSiblings(tree[1][0][0]).Select(x => x.Value));
        }

        #endregion

        #region PreOrderTraversal

        [Fact]
        public void PreOrderTraversal_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'PreOrderTraversal' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.PreOrderTraversal(tree).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.PreOrderTraversal(tree, true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.PreOrderTraversal(tree, false).ToArray());
        }

        [Fact]
        public void PreOrderTraversal_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'PreOrderTraversal' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.PreOrderTraversal(null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.PreOrderTraversal(null, true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.PreOrderTraversal(null, false).ToArray());
        }

        [Fact]
        public void PreOrderTraversal()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            int[] node1ExpectedResult = new int[] { 1, 2, 3 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 4, 5, 6 };
            int[] node5ExpectedResult = new int[] { 5, 6 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'PreOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.PreOrderTraversal(tree, true).Select(x => x.Value));
            Assert.Equal(
                node0ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree, false).Select(x => x.Value));
            Assert.Equal(
                node0ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PreOrderTraversal(tree[0], true).Select(x => x.Value));
            Assert.Equal(
                node1ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[0], false).Select(x => x.Value));
            Assert.Equal(
                node1ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[0]).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PreOrderTraversal(tree[0][0], true).Select(x => x.Value));
            Assert.Equal(
                node2ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[0][0], false).Select(x => x.Value));
            Assert.Equal(
                node2ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[0][0]).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PreOrderTraversal(tree[0][1], true).Select(x => x.Value));
            Assert.Equal(
                node3ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[0][1], false).Select(x => x.Value));
            Assert.Equal(
                node3ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[0][1]).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PreOrderTraversal(tree[1], true).Select(x => x.Value));
            Assert.Equal(
                node4ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[1], false).Select(x => x.Value));
            Assert.Equal(
                node4ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[1]).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PreOrderTraversal(tree[1][0], true).Select(x => x.Value));
            Assert.Equal(
                node5ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[1][0], false).Select(x => x.Value));
            Assert.Equal(
                node5ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[1][0]).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PreOrderTraversal(tree[1][0][0], true).Select(x => x.Value));
            Assert.Equal(
                node6ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[1][0][0], false).Select(x => x.Value));
            Assert.Equal(
                node6ExpectedResult.Skip(1),
                walker.PreOrderTraversal(tree[1][0][0]).Select(x => x.Value));
        }

        #endregion
    }
}
