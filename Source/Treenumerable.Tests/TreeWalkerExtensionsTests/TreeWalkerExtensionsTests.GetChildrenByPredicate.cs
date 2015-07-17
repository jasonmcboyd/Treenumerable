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
        public void GetChildrenByPredicate_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();
            
            // Create a null ITreeWalker.
            NodeWalker<int> walker = null;

            // Assert that 'GetChildren' throws an 'ArgumentNullException' when the tree 
            // walker is null.
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetChildren(new Node<int>[] { tree }, (n) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "walker",
                () => walker.GetChildren(tree, (n) => true).ToArray());
        }

        [Fact]
        public void GetChildrenByPredicate_NullNode_ArgumentNullExceptionThrown()
        {
            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetChildren' throws an 'ArgumentNullException' when the node is
            // null.
            Assert.Throws<ArgumentNullException>(
                "nodes",
                () => walker.GetChildren((IEnumerable<Node<int>>)null, (n) => true).ToArray());
            Assert.Throws<ArgumentNullException>(
                "node",
                () => walker.GetChildren((Node<int>)null, (n) => true).ToArray());
        }

        [Fact]
        public void GetChildrenByPredicate_NullPredicate_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetChildren' throws an 'ArgumentNullException' when the predicate 
            // is null.
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.GetChildren(new Node<int>[] { tree }, (Func<Node<int>, bool>)null).ToArray());
            Assert.Throws<ArgumentNullException>(
                "predicate",
                () => walker.GetChildren(tree, (Func<Node<int>, bool>)null).ToArray());
        }

        [Fact]
        public void GetChildrenByPredicate_PredicateTests()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Create test predicates and the expected results.
            var testCases = new[]
            {
                new {
                    Predicate = new Func<Node<int>, bool>(i => i.Value % 2 == 0),
                    ExpectedResults = new int[] { 4 } },
                new {
                    Predicate = new Func<Node<int>, bool>(i => i.Value % 2 == 1),
                    ExpectedResults = new int[] { 1 } },
                new {
                    Predicate = new Func<Node<int>, bool>(i => i.Value >= 2),
                    ExpectedResults = new int[] { 4 } },
            };

            // Assert that 'GetChildren' returns the expected results for each predicate.
            foreach (var testCase in testCases)
            {
                Assert.Equal(
                    walker
                        .GetChildren(tree, testCase.Predicate)
                        .Select(x => x.Value),
                    testCase.ExpectedResults);
                Assert.Equal(
                    walker
                        .GetChildren(new Node<int>[] { tree }, testCase.Predicate)
                        .Select(x => x.Value),
                    testCase.ExpectedResults);
            }
        }
    }
}
