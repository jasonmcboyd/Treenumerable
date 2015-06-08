using System;
using System.Collections.Generic;
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
                Node.Create(0).AddChildren(
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
            foreach (Node<int> node in walker.PreOrderTraversal(tree))
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

        #region GetParentOrDefault

        [Fact]
        public void GetParentOrDefault_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetParent' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetParentOrDefault(tree));
        }

        [Fact]
        public void GetParentOrDefault_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetParent' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetParentOrDefault(null));
        }

        [Fact]
        public void GetParentOrDefault_CorrectNodeReturned()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'TryGetParent' returns the node's parent.
            foreach (Node<int> node in walker.PreOrderTraversal(tree))
            {
                Node<int> parent;
                if (node == tree)
                {
                    Assert.False(walker.TryGetParent(node, out parent));
                }
                else
                {
                    Assert.True(walker.TryGetParent(node, out parent));
                }
                Assert.Equal(parent, walker.GetParentOrDefault(node));
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
            foreach (Node<int> node in walker.PreOrderTraversal(tree))
            {
                Assert.Equal(tree.Value, walker.GetRoot(node).Value);
            }
        }

        #endregion

        #region HasChildren

        [Fact]
        public void HasChildren_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'HasChildren' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.HasChildren(tree));
        }

        [Fact]
        public void HasChildren_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'HasChildren' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.HasChildren(null));
        }

        [Fact]
        public void HasChildren()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'HasChildren' returns the correct value.
            Assert.Equal(true, walker.HasChildren(tree));
            Assert.Equal(true, walker.HasChildren(tree[0]));
            Assert.Equal(false, walker.HasChildren(tree[0][0]));
            Assert.Equal(false, walker.HasChildren(tree[0][1]));
            Assert.Equal(true, walker.HasChildren(tree[1]));
            Assert.Equal(true, walker.HasChildren(tree[1][0]));
            Assert.Equal(false, walker.HasChildren(tree[1][0][0]));
        }

        #endregion

        #region HasParent

        [Fact]
        public void HasParent_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'HasParent' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.HasParent(tree));
        }

        [Fact]
        public void HasParent_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'HasParent' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.HasParent(null));
        }

        [Fact]
        public void HasParent()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert the 'HasParent' returns the correct value.
            Assert.Equal(false, walker.HasParent(tree));
            Assert.Equal(true, walker.HasParent(tree[0]));
            Assert.Equal(true, walker.HasParent(tree[0][0]));
            Assert.Equal(true, walker.HasParent(tree[0][1]));
            Assert.Equal(true, walker.HasParent(tree[1]));
            Assert.Equal(true, walker.HasParent(tree[1][0]));
            Assert.Equal(true, walker.HasParent(tree[1][0][0]));
        }

        #endregion

        #region GetSiblings

        [Fact]
        public void GetSiblings_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetSiblings' throws an 'ArgumentNullException' when the tree walker
            // is null.
            Assert.Throws<ArgumentNullException>("walker", () => walker.GetSiblings(tree).ToArray());
        }

        [Fact]
        public void GetSiblings_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetSiblings' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>("node", () => walker.GetSiblings(null).ToArray());
        }

        [Fact]
        public void GetSiblings()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // For each node in the tree assert that 'GetSiblings' returns the correct 
            // elements.
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetSiblings(tree).Select(x => x.Value));
            Assert.Equal(
                new int[] { 4 },
                walker.GetSiblings(tree[0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 3 },
                walker.GetSiblings(tree[0][0]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 2 },
                walker.GetSiblings(tree[0][1]).Select(x => x.Value));
            Assert.Equal(
                new int[] { 1 },
                walker.GetSiblings(tree[1]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetSiblings(tree[1][0]).Select(x => x.Value));
            Assert.Equal(
                Enumerable.Empty<int>(),
                walker.GetSiblings(tree[1][0][0]).Select(x => x.Value));
        }

        #endregion

        #region LevelOrderTraversal

        [Fact]
        public void LevelOrderTraversal_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'LevelOrderTraversal' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.LevelOrderTraversal(tree).ToArray());
        }

        [Fact]
        public void LevelOrderTraversal_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'LevelOrderTraversal' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.LevelOrderTraversal(null).ToArray());
        }

        [Fact]
        public void LevelOrderTraversal()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 0, 1, 4, 2, 3, 5, 6 };
            int[] node1ExpectedResult = new int[] { 1, 2, 3 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 4, 5, 6 };
            int[] node5ExpectedResult = new int[] { 5, 6 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'LevelOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.LevelOrderTraversal(tree).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.LevelOrderTraversal(tree[0]).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.LevelOrderTraversal(tree[0][0]).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.LevelOrderTraversal(tree[0][1]).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.LevelOrderTraversal(tree[1]).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.LevelOrderTraversal(tree[1][0]).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.LevelOrderTraversal(tree[1][0][0]).Select(x => x.Value));
        }

        [Fact]
        public void LevelOrderTraversal_ShortCircuitDepth()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 0, 1, 4 };
            int[] node1ExpectedResult = new int[] { 1, 2, 3 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 4, 5 };
            int[] node5ExpectedResult = new int[] { 5, 6 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'LevelOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.LevelOrderTraversal(tree, (n, i) => i > 1).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.LevelOrderTraversal(tree[0], (n, i) => i > 1).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.LevelOrderTraversal(tree[0][0], (n, i) => i > 1).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.LevelOrderTraversal(tree[0][1], (n, i) => i > 1).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.LevelOrderTraversal(tree[1], (n, i) => i > 1).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.LevelOrderTraversal(tree[1][0], (n, i) => i > 1).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.LevelOrderTraversal(tree[1][0][0], (n, i) => i > 1).Select(x => x.Value));
        }

        [Fact]
        public void LevelOrderTraversal_ShortCircuitOddNumbers()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 0, 4 };
            int[] node1ExpectedResult = new int[] { };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { };
            int[] node4ExpectedResult = new int[] { 4 };
            int[] node5ExpectedResult = new int[] { };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'LevelOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.LevelOrderTraversal(tree, (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.LevelOrderTraversal(tree[0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.LevelOrderTraversal(tree[0][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.LevelOrderTraversal(tree[0][1], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.LevelOrderTraversal(tree[1], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.LevelOrderTraversal(tree[1][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.LevelOrderTraversal(tree[1][0][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));
        }

        #endregion

        #region PostOrderTraversal

        [Fact]
        public void PostOrderTraversal_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'PostOrderTraversal' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.PostOrderTraversal(tree).ToArray());
        }

        [Fact]
        public void PostOrderTraversal_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'PostOrderTraversal' throws an 'ArgumentNullException' when the node is null.
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.PostOrderTraversal(null).ToArray());
        }

        [Fact]
        public void PostOrderTraversal()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 2, 3, 1, 6, 5, 4, 0 };
            int[] node1ExpectedResult = new int[] { 2, 3, 1 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 6, 5, 4 };
            int[] node5ExpectedResult = new int[] { 6, 5 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'PostOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.PostOrderTraversal(tree).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PostOrderTraversal(tree[0]).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PostOrderTraversal(tree[0][0]).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PostOrderTraversal(tree[0][1]).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PostOrderTraversal(tree[1]).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PostOrderTraversal(tree[1][0]).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PostOrderTraversal(tree[1][0][0]).Select(x => x.Value));
        }

        [Fact]
        public void PostOrderTraversal_ShortCircuitDepth()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 1, 4, 0 };
            int[] node1ExpectedResult = new int[] { 2, 3, 1 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 5, 4 };
            int[] node5ExpectedResult = new int[] { 6, 5 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'PreOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.PostOrderTraversal(tree, (n, i) => i > 1).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PostOrderTraversal(tree[0], (n, i) => i > 1).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PostOrderTraversal(tree[0][0], (n, i) => i > 1).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PostOrderTraversal(tree[0][1], (n, i) => i > 1).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PostOrderTraversal(tree[1], (n, i) => i > 1).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PostOrderTraversal(tree[1][0], (n, i) => i > 1).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PostOrderTraversal(tree[1][0][0], (n, i) => i > 1).Select(x => x.Value));
        }

        [Fact]
        public void PostOrderTraversal_ShortCircuitOddNumbers()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 4, 0 };
            int[] node1ExpectedResult = new int[] { };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { };
            int[] node4ExpectedResult = new int[] { 4 };
            int[] node5ExpectedResult = new int[] { };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'PostOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.PostOrderTraversal(tree, (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PostOrderTraversal(tree[0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PostOrderTraversal(tree[0][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PostOrderTraversal(tree[0][1], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PostOrderTraversal(tree[1], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PostOrderTraversal(tree[1][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PostOrderTraversal(tree[1][0][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));
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
                walker.PreOrderTraversal(tree).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PreOrderTraversal(tree[0]).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PreOrderTraversal(tree[0][0]).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PreOrderTraversal(tree[0][1]).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PreOrderTraversal(tree[1]).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PreOrderTraversal(tree[1][0]).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PreOrderTraversal(tree[1][0][0]).Select(x => x.Value));
        }

        [Fact]
        public void PreOrderTraversal_ShortCircuitDepth()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 0, 1, 4 };
            int[] node1ExpectedResult = new int[] { 1, 2, 3 };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { 3 };
            int[] node4ExpectedResult = new int[] { 4, 5 };
            int[] node5ExpectedResult = new int[] { 5, 6 };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'PreOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.PreOrderTraversal(tree, (n, i) => i > 1).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PreOrderTraversal(tree[0], (n, i) => i > 1).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PreOrderTraversal(tree[0][0], (n, i) => i > 1).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PreOrderTraversal(tree[0][1], (n, i) => i > 1).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PreOrderTraversal(tree[1], (n, i) => i > 1).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PreOrderTraversal(tree[1][0], (n, i) => i > 1).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PreOrderTraversal(tree[1][0][0], (n, i) => i > 1).Select(x => x.Value));
        }

        [Fact]
        public void PreOrderTraversal_ShortCircuitOddNumbers()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create arrays of the results expected from each node.
            int[] node0ExpectedResult = new int[] { 0, 4 };
            int[] node1ExpectedResult = new int[] { };
            int[] node2ExpectedResult = new int[] { 2 };
            int[] node3ExpectedResult = new int[] { };
            int[] node4ExpectedResult = new int[] { 4 };
            int[] node5ExpectedResult = new int[] { };
            int[] node6ExpectedResult = new int[] { 6 };

            // For each node in the tree assert that 'PreOrderTraversal' returns the correct 
            // elements.

            // Node 0:
            Assert.Equal(
                node0ExpectedResult,
                walker.PreOrderTraversal(tree, (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 1:
            Assert.Equal(
                node1ExpectedResult,
                walker.PreOrderTraversal(tree[0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 2:
            Assert.Equal(
                node2ExpectedResult,
                walker.PreOrderTraversal(tree[0][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 3:
            Assert.Equal(
                node3ExpectedResult,
                walker.PreOrderTraversal(tree[0][1], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 4:
            Assert.Equal(
                node4ExpectedResult,
                walker.PreOrderTraversal(tree[1], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 5:
            Assert.Equal(
                node5ExpectedResult,
                walker.PreOrderTraversal(tree[1][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));

            // Node 6:
            Assert.Equal(
                node6ExpectedResult,
                walker.PreOrderTraversal(tree[1][0][0], (n, i) => n.Value % 2 == 1).Select(x => x.Value));
        }

        #endregion

        #region SelectDescendants

        [Fact]
        public void SelectDescendants_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'SelectDescendants' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.SelectDescendants(new Node<int>[] { tree }, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.SelectDescendants(new Node<int>[] { tree }, (n) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.SelectDescendants(tree, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.SelectDescendants(tree, (n) => true).ToArray());
        }

        [Fact]
        public void SelectDescendants_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'SelectDescendants' throws an 'ArgumentNullException' when the node is
            // null.
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.SelectDescendants((IEnumerable<Node<int>>)null, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.SelectDescendants((IEnumerable<Node<int>>)null, (n) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.SelectDescendants((Node<int>)null, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.SelectDescendants((Node<int>)null, (n) => true).ToArray());
        }

        [Fact]
        public void SelectDescendants_NullPredicate_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'SelectDescendants' throws an 'ArgumentNullException' when the predicate 
            // is null.
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.SelectDescendants(new Node<int>[] { tree }, (Func<Node<int>, int, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.SelectDescendants(new Node<int>[] { tree }, (Func<Node<int>, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.SelectDescendants(tree, (Func<Node<int>, int, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.SelectDescendants(tree, (Func<Node<int>, bool>)null).ToArray());
        }

        [Fact]
        public void SelectDescendants_PredicateTests()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create test predicates and the expected results.
            var testCases = new[]
            {
                new {
                    Predicate = new Func<Node<int>, bool>(i => i.Value % 2 == 0),
                    ExpectedResults = new int[] { 0 } },
                new {
                    Predicate = new Func<Node<int>, bool>(i => i.Value % 2 == 1),
                    ExpectedResults = new int[] { 1, 5 } },
                new {
                    Predicate = new Func<Node<int>, bool>(i => i.Value >= 2),
                    ExpectedResults = new int[] { 2, 3, 4 } },
            };

            // Assert that 'SelectDescendants' returns the expected results for each predicate.
            foreach (var testCase in testCases)
            {
                Assert.Equal(
                    walker
                        .SelectDescendants(tree, testCase.Predicate)
                        .Select(x => x.Value),
                    testCase.ExpectedResults);
                Assert.Equal(
                    walker
                        .SelectDescendants(new Node<int>[] { tree }, testCase.Predicate)
                        .Select(x => x.Value),
                    testCase.ExpectedResults);
            }
        }

        #endregion
    }
}
