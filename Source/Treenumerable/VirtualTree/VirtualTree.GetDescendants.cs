using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets the nearest descendants based on a predicate.
        /// </summary>
        /// <param name="predicate">
        /// A predicate to test each <see cref="VirtualTree&lt;T&gt;"/> for selection.  The
        /// argument is the current node being evaluated.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public VirtualTreeEnumerable<T> GetDescendants(Func<T, bool> predicate)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, predicate)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Gets the nearest descendants based on a predicate.
        /// </summary>
        /// <param name="predicate">
        /// A predicate to test each <see cref="VirtualTree&lt;T&gt;"/> for selection.  The first
        /// argument is the current node being evaluated and the second argument is the depth of
        /// the current node relative to the original node that the query began on.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching nodes in the tree ordered based on a pre-order traversal.
        /// </returns>
        public VirtualTreeEnumerable<T> GetDescendants(Func<T, int, bool> predicate)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, predicate)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Gets the nearest descendants that match the <paramref name="key"/>.
        /// </summary>
        /// <param name="key">
        /// The key each <see cref="VirtualTree&lt;T&gt;"/> will be compared to.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching descendants in the tree ordered based on a pre-order traversal.
        /// </returns>
        public VirtualTreeEnumerable<T> GetDescendants(T key)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, key, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Gets the nearest descendants that match the <paramref name="key"/>.
        /// </summary>
        /// <param name="key">
        /// The key each <see cref="VirtualTree&lt;T&gt;"/> will be compared to.
        /// </param>
        /// /// <param name="comparer">
        /// The <see cref="IEqualityComparer&lt;T&gt;"/> used to compare the key and the this.  If
        /// this is null then the default <see cref="EqualityComparer&lt;T&gt;.Default"/> will be
        /// used.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching descendants in the tree ordered based on a pre-order traversal.
        /// </returns>
        public VirtualTreeEnumerable<T> GetDescendants(T key, IEqualityComparer<T> comparer)
        {
            return
                this
                .TreeWalker
                .GetDescendants(this.Root, key, comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
