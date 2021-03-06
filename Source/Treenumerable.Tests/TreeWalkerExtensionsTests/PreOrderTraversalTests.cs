﻿using System;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class PreOrderTraversalTests
    {
        [Fact]
        public void PreOrderTraversal_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

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
            var tree = TestTreeFactory.GetSimpleTree();

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

        [Theory]
        [InlineData(new int[] { }, ExcludeOption.ExcludeTree, new int[] { 0, 1, 4 })]
        [InlineData(new int[] { 0 }, ExcludeOption.ExcludeTree, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 0, 0 }, ExcludeOption.ExcludeTree, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, ExcludeOption.ExcludeTree, new int[] { 3 })]
        [InlineData(new int[] { 1 }, ExcludeOption.ExcludeTree, new int[] { 4, 5 })]
        [InlineData(new int[] { 1, 0 }, ExcludeOption.ExcludeTree, new int[] { 5, 6 })]
        [InlineData(new int[] { 1, 0, 0 }, ExcludeOption.ExcludeTree, new int[] { 6 })]
        [InlineData(new int[] { }, ExcludeOption.ExcludeDescendants, new int[] { 0, 1, 2, 3, 4, 5 })]
        [InlineData(new int[] { 0 }, ExcludeOption.ExcludeDescendants, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 0, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, ExcludeOption.ExcludeDescendants, new int[] { 3 })]
        [InlineData(new int[] { 1 }, ExcludeOption.ExcludeDescendants, new int[] { 4, 5, 6 })]
        [InlineData(new int[] { 1, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 5, 6 })]
        [InlineData(new int[] { 1, 0, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 6 })]
        public void PreOrderTraversal_ShortCircuitDepth(
            int[] traversalToStartNode,
            ExcludeOption excludeOption,
            int[] expectedResults)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Get the node to begin traversing from.
            var startNode = tree;
            foreach (int i in traversalToStartNode)
            {
                startNode = startNode[i];
            }

            // Assert that the correct sequence is returned.
            Assert.Equal(
                expectedResults,
                walker.PreOrderTraversal(startNode, (n, i) => i > 1, excludeOption).Select(x => x.Value));
        }

        [Theory]
        [InlineData(new int[] { }, ExcludeOption.ExcludeTree, new int[] { 0, 4 })]
        [InlineData(new int[] { 0 }, ExcludeOption.ExcludeTree, new int[] { })]
        [InlineData(new int[] { 0, 0 }, ExcludeOption.ExcludeTree, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, ExcludeOption.ExcludeTree, new int[] { })]
        [InlineData(new int[] { 1 }, ExcludeOption.ExcludeTree, new int[] { 4 })]
        [InlineData(new int[] { 1, 0 }, ExcludeOption.ExcludeTree, new int[] { })]
        [InlineData(new int[] { 1, 0, 0 }, ExcludeOption.ExcludeTree, new int[] { 6 })]
        [InlineData(new int[] { }, ExcludeOption.ExcludeDescendants, new int[] { 0, 1, 4, 5 })]
        [InlineData(new int[] { 0 }, ExcludeOption.ExcludeDescendants, new int[] { 1 })]
        [InlineData(new int[] { 0, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, ExcludeOption.ExcludeDescendants, new int[] { 3 })]
        [InlineData(new int[] { 1 }, ExcludeOption.ExcludeDescendants, new int[] { 4, 5 })]
        [InlineData(new int[] { 1, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 5 })]
        [InlineData(new int[] { 1, 0, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 6 })]
        public void PreOrderTraversal_ShortCircuitOddNumbers(
            int[] traversalToStartNode,
            ExcludeOption excludeOption,
            int[] expectedResults)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Get the node to begin traversing from.
            var startNode = tree;
            foreach (int i in traversalToStartNode)
            {
                startNode = startNode[i];
            }

            // Assert that the correct sequence is returned.
            Assert.Equal(
                expectedResults,
                walker.PreOrderTraversal(startNode, (n, i) => n.Value % 2 == 1, excludeOption).Select(x => x.Value));
        }

        [Theory]
        [InlineData(ExcludeOption.ExcludeDescendants, new int[] { 0 })]
        [InlineData(ExcludeOption.ExcludeTree, new int[] { })]
        public void PreOrderTraversal_ShortCircuitRootNode(
            ExcludeOption excludeOption,
            int[] expectedResults)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that the correct sequence is returned.
            Assert.Equal(
                expectedResults,
                walker.PreOrderTraversal(tree, (n, i) => n.Value == 0, excludeOption).Select(x => x.Value));
        }

        [Theory]
        [InlineData(ExcludeOption.ExcludeDescendants, new int[] { 0 })]
        [InlineData(ExcludeOption.ExcludeTree, new int[] { })]
        public void PreOrderTraversal_SingleNode(
            ExcludeOption excludeOption,
            int[] expectedResults)
        {
            // Get a valid tree.
            var tree = Node.Create(0);

            // Get a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that the correct sequence is returned.
            Assert.Equal(
                expectedResults,
                walker.PreOrderTraversal(tree, (n, i) => n.Value == 0, excludeOption).Select(x => x.Value));
        }
    }
}
