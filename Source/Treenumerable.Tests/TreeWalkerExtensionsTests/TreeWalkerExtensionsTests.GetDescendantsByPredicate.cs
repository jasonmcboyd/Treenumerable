using System;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetDescendants_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetDescendants' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(new Node<int>[] { tree }, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(new Node<int>[] { tree }, (n) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(tree, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetDescendants(tree, (n) => true).ToArray());
        }

        [Fact]
        public void GetDescendants_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDescendants' throws an 'ArgumentNullException' when the node is
            // null.
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetDescendants((IEnumerable<Node<int>>)null, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetDescendants((IEnumerable<Node<int>>)null, (n) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetDescendants((Node<int>)null, (n, i) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetDescendants((Node<int>)null, (n) => true).ToArray());
        }

        [Fact]
        public void GetDescendants_NullPredicate_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = this.GetTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDescendants' throws an 'ArgumentNullException' when the predicate 
            // is null.
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.GetDescendants(new Node<int>[] { tree }, (Func<Node<int>, int, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.GetDescendants(new Node<int>[] { tree }, (Func<Node<int>, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.GetDescendants(tree, (Func<Node<int>, int, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.GetDescendants(tree, (Func<Node<int>, bool>)null).ToArray());
        }

        [Fact]
        public void GetDescendants_PredicateTests()
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

            // Assert that 'GetDescendants' returns the expected results for each predicate.
            foreach (var testCase in testCases)
            {
                Assert.Equal(
                    walker
                        .GetDescendants(tree, testCase.Predicate)
                        .Select(x => x.Value),
                    testCase.ExpectedResults);
                Assert.Equal(
                    walker
                        .GetDescendants(new Node<int>[] { tree }, testCase.Predicate)
                        .Select(x => x.Value),
                    testCase.ExpectedResults);
            }
        }
    }
}
