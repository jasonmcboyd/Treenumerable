using System;
using System.Collections.Generic;
using System.Linq;
using Treenumerable.Tests.TreeBuilder;
using Xunit;
using Xunit.Extensions;

namespace Treenumerable.Tests
{
    public partial class TreeWalkerExtensionsTests
    {
        [Fact]
        public void GetDescendants_NullWalker_ArgumentNullExceptionThrown()
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

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
            var tree = TestTreeFactory.GetSimpleTree();

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

        [Theory]
        [MemberData("ValuePredicateTestData")]
        public void GetDescendants_ValuePredicateTests(
            Func<Node<int>, bool> predicate, 
            int[] expectedResult)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();
            
            // Assert that 'GetDescendants' returns the expected results for each predicate.
            Assert.Equal(
                expectedResult,
                walker
                    .GetDescendants(tree, predicate)
                    .Select(x => x.Value));
            Assert.Equal(
                expectedResult,
                walker
                    .GetDescendants(new Node<int>[] { tree }, predicate)
                    .Select(x => x.Value));
        }

        public static IEnumerable<object[]> ValuePredicateTestData
        {
            get
            {
                return new []
                {
                    new object[] {
                        new Func<Node<int>, bool>(i => i.Value % 2 == 0),
                        new int[] { 2, 4 }},
                    new object[] {
                        new Func<Node<int>, bool>(i => i.Value % 2 == 1),
                        new int[] { 1, 5 }},
                    new object[] {
                        new Func<Node<int>, bool>(i => i.Value >= 2 && i.Value != 4),
                        new int[] { 2, 3, 5 }}
                };
            }
        }

        [Theory]
        [MemberData("DepthPredicateTestData")]
        public void GetDescendants_DepthPredicateTests(
            Func<Node<int>, int, bool> predicate,
            int[] expectedResult)
        {
            // Get a valid tree.
            var tree = TestTreeFactory.GetSimpleTree();

            // Create a valid ITreeWalker.
            NodeWalker<int> walker = new NodeWalker<int>();

            // Assert that 'GetDescendants' returns the expected results for each predicate.
            Assert.Equal(
                expectedResult,
                walker
                    .GetDescendants(tree, predicate)
                    .Select(x => x.Value));
            Assert.Equal(
                expectedResult,
                walker
                    .GetDescendants(new Node<int>[] { tree }, predicate)
                    .Select(x => x.Value));
        }

        public static IEnumerable<object[]> DepthPredicateTestData
        {
            get
            {
                return new[]
                {
                    new object[] {
                        new Func<Node<int>, int, bool>((i, d) => i.Value % 2 == 0),
                        new int[] { 2, 4 }},
                    new object[] {
                        new Func<Node<int>, int, bool>((i, d) => i.Value % 2 == 1),
                        new int[] { 1, 5 }},
                    new object[] {
                        new Func<Node<int>, int, bool>((i, d) => i.Value >= 2 && i.Value != 4),
                        new int[] { 2, 3, 5 }},
                    new object[] {
                        new Func<Node<int>, int, bool>((i, d) => d == 1),
                        new int[] { 1, 4 }},
                    new object[] {
                        new Func<Node<int>, int, bool>((i, d) => d == 2),
                        new int[] { 2, 3, 5 }},
                    new object[] {
                        new Func<Node<int>, int, bool>((i, d) => d == 3),
                        new int[] { 6 }}
                };
            }
        }
        
    }
}
