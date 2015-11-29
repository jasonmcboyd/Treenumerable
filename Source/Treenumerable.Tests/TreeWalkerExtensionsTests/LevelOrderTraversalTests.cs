using System;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests.TreeWalkerExtensionsTests
{
    public class LevelOrderTraversalTests
    {
        [Fact]
        public void LevelOrderTraversal_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

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
            var tree = TestTreeFactory.GetSimpleTree();

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

        [Theory]
        [InlineData(new int[] { }, ExcludeOption.ExcludeTree, new int[] { 0, 1, 4 })]
        [InlineData(new int[] { 0 }, ExcludeOption.ExcludeTree, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 0, 0 }, ExcludeOption.ExcludeTree, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, ExcludeOption.ExcludeTree, new int[] { 3 })]
        [InlineData(new int[] { 1 }, ExcludeOption.ExcludeTree, new int[] { 4, 5 })]
        [InlineData(new int[] { 1, 0 }, ExcludeOption.ExcludeTree, new int[] { 5, 6 })]
        [InlineData(new int[] { 1, 0, 0 }, ExcludeOption.ExcludeTree, new int[] { 6 })]
        [InlineData(new int[] { }, ExcludeOption.ExcludeDescendants, new int[] { 0, 1, 4, 2, 3, 5 })]
        [InlineData(new int[] { 0 }, ExcludeOption.ExcludeDescendants, new int[] { 1, 2, 3 })]
        [InlineData(new int[] { 0, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 2 })]
        [InlineData(new int[] { 0, 1 }, ExcludeOption.ExcludeDescendants, new int[] { 3 })]
        [InlineData(new int[] { 1 }, ExcludeOption.ExcludeDescendants, new int[] { 4, 5, 6 })]
        [InlineData(new int[] { 1, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 5, 6 })]
        [InlineData(new int[] { 1, 0, 0 }, ExcludeOption.ExcludeDescendants, new int[] { 6 })]
        public void LevelOrderTraversal_ShortCircuitDepth(
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
                walker.LevelOrderTraversal(startNode, (n, i) => i > 1, excludeOption).Select(x => x.Value));
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
        public void LevelOrderTraversal_ShortCircuitOddNumbers(
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
                walker.LevelOrderTraversal(startNode, (n, i) => n.Value % 2 == 1, excludeOption).Select(x => x.Value));
        }
    }
}
