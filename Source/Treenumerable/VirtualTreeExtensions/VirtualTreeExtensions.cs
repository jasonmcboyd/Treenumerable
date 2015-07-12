using System;
using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static class VirtualTreeExtensions
    {
        public static IEnumerable<VirtualTree<T>> GetAncestors<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetAncestors(virtualTree.Root)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static int GetDegree<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetDegree(virtualTree.Root);
        }

        public static int GetDepth<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetDepth(virtualTree.Root);
        }

        public static int GetHeight<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetHeight(virtualTree.Root);
        }

        public static IEnumerable<VirtualTree<T>> GetLeaves<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetLeaves(virtualTree.Root)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static IEnumerable<VirtualTree<T>> GetLevel<T>(this VirtualTree<T> virtualTree, int depth)
        {
            return
                virtualTree
                .TreeWalker
                .GetLevel(virtualTree.Root, depth)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static T GetParentOrDefault<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetParentOrDefault(virtualTree.Root);
        }

        public static T GetRoot<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetRoot(virtualTree.Root);
        }

        public static IEnumerable<VirtualTree<T>> GetSiblings<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .GetSiblings(virtualTree.Root)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static bool HasChildren<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .HasChildren(virtualTree.Root);
        }

        public static bool HasParent<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .HasParent(virtualTree.Root);
        }

        public static IEnumerable<T> LevelOrderTraversal<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .LevelOrderTraversal(virtualTree.Root);
        }

        public static IEnumerable<T> LevelOrderTraversal<T>(
            this VirtualTree<T> virtualTree, 
            Func<T, int, bool> predicate,
            ExcludeOption excludeOption)
        {
            return
                virtualTree
                .TreeWalker
                .LevelOrderTraversal(virtualTree.Root, predicate, excludeOption);
        }

        public static IEnumerable<T> PreOrderTraversal<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .PreOrderTraversal(virtualTree.Root);
        }

        public static IEnumerable<T> PreOrderTraversal<T>(
            this VirtualTree<T> virtualTree, 
            Func<T, int, bool> excludeSubtreePredicate,
            ExcludeOption excludeOption)
        {
            return
                virtualTree
                .TreeWalker
                .PreOrderTraversal(virtualTree.Root, excludeSubtreePredicate, excludeOption);
        }

        public static IEnumerable<T> PostOrderTraversal<T>(this VirtualTree<T> virtualTree)
        {
            return
                virtualTree
                .TreeWalker
                .PostOrderTraversal(virtualTree.Root);
        }

        public static IEnumerable<T> PostOrderTraversal<T>(
            this VirtualTree<T> virtualTree,
            Func<T, int, bool> excludeSubtreePredicate,
            ExcludeOption excludeOption)
        {
            return
                virtualTree
                .TreeWalker
                .PostOrderTraversal(virtualTree.Root, excludeSubtreePredicate, excludeOption);
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this VirtualTree<T> virtualTree, 
            Func<T, bool> predicate)
        {
            return
                virtualTree
                .TreeWalker
                .SelectDescendants(virtualTree.Root, predicate)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this VirtualTree<T> virtualTree, 
            Func<T, int, bool> predicate)
        {
            return
                virtualTree
                .TreeWalker
                .SelectDescendants(virtualTree.Root, predicate)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this VirtualTree<T> virtualTree, 
            T key)
        {
            return
                virtualTree
                .TreeWalker
                .SelectDescendants(virtualTree.Root, key)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static IEnumerable<VirtualTree<T>> SelectDescendants<T>(
            this VirtualTree<T> 
            virtualTree, 
            T key, 
            IEqualityComparer<T> comparer)
        {
            return
                virtualTree
                .TreeWalker
                .SelectDescendants(virtualTree.Root, key, comparer)
                .Select(x => virtualTree.CreateFromSelf(x));
        }

        public static IEnumerable<VirtualTree<T>> SelectChildren<T>(
            this VirtualTree<T> virtualTree,
            Func<T, bool> predicate)
        {
            return
                virtualTree
                .TreeWalker
                .SelectChildren(virtualTree.Root, predicate)
                .Select(n => virtualTree.CreateFromSelf(n));
        }

        public static IEnumerable<VirtualTree<T>> SelectChildren<T>(
            this VirtualTree<T> virtualTree,
            T key)
        {
            return
                virtualTree
                .TreeWalker
                .SelectChildren(virtualTree.Root, key)
                .Select(n => virtualTree.CreateFromSelf(n));
        }

        public static IEnumerable<VirtualTree<T>> SelectChildren<T>(
            this VirtualTree<T> virtualTree,
            T key,
            IEqualityComparer<T> comparer)
        {
            return
                virtualTree
                .TreeWalker
                .SelectChildren(virtualTree.Root, key, comparer)
                .Select(n => virtualTree.CreateFromSelf(n));
        }

        public static VirtualTree<T> GetChildAt<T>(
            this VirtualTree<T> virtualTree,
            int index)
        {
            return
                virtualTree
                .CreateFromSelf(
                    virtualTree
                    .TreeWalker
                    .GetChildAt(virtualTree.Root, index));
        }

        public static VirtualTree<T> GetChildAtOrDefault<T>(
            this VirtualTree<T> virtualTree,
            int index)
        {
            return
                virtualTree
                .CreateFromSelf(
                    virtualTree
                    .TreeWalker
                    .GetChildAtOrDefault(virtualTree.Root, index));
        }
    }
}
