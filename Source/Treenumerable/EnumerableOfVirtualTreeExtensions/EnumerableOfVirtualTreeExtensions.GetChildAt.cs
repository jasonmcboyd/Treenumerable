using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        // TODO: Comments
        public static VirtualTreeEnumerable<T> GetChildAt<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index");
            }

            if (virtualTrees == null)
            {
                throw new ArgumentNullException("virtualTrees");
            }

            return
                virtualTrees
                .GetChildAtImplementation(index)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Takes an <see cref="IEnumerable&lt;VirtualTree&lt;T&gt;&gt;"/> and returns each 
        /// <see cref="VirtualTree&lt;T&gt;"/>'s child at the specified index.  If the index is
        /// greater than the number of children then no child is returned for that 
        /// <see cref="VirtualTree&lt;T&gt;"/>.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="virtualTrees">
        /// The <see cref="VirtualTree&lt;T&gt;"/>'s that are to have their child returned.
        /// </param>
        /// <param name="index">
        /// The index of the child to be returned.
        /// </param>
        /// <returns>
        /// An <see cref="VirtualTreeEnumerable&lt;T&gt;"/> representing the selected
        /// child from each <see cref="VirtualTree&lt;T&gt;"/>s.
        /// </returns>
        private static IEnumerable<VirtualTree<T>> GetChildAtImplementation<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            int index)
        {
            foreach (VirtualTree<T> tree in virtualTrees)
            {
                T child;
                if(tree.TreeWalker.TryGetChildAt(tree.Root, index, out child))
                {
                    yield return tree.ShallowCopy(child);
                }
            }
        }
    }
}
