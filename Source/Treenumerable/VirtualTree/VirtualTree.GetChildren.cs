using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Returns the children of the <see cref="VirtualTree&lt;T&gt;"/>.
        /// </summary>
        /// <returns>
        /// The <see cref="VirtualTree&lt;T&gt;"/>'s children or an empty 
        /// <see cref="VirtualTreeEnumerable&lt;T&gt;"/> if it has no children.
        /// </returns>
        public VirtualTreeEnumerable<T> GetChildren()
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Gets the children of the <see cref="VirtualTree&lt;T&gt;"/> based on a predicate.
        /// </summary>
        /// <param name="predicate">
        /// A predicate to test each child.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching children or an empty <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/>
        /// if no children are selected.
        /// </returns>
        public VirtualTreeEnumerable<T> GetChildren(Func<T, bool> predicate)
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root, predicate)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Gets the children that match the <paramref name="key"/>.
        /// </summary>
        /// <param name="key">
        /// The key that each child will be compared to.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching children or an empty <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/>
        /// if no children match.
        /// </returns>
        public VirtualTreeEnumerable<T> GetChildren(T key)
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root, key, this.Comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }

        /// <summary>
        /// Gets the children that match the <paramref name="key"/>.
        /// </summary>
        /// <param name="key">
        /// The key that each child will be compared to.
        /// </param>
        /// <param name="comparer">
        /// The <see cref="IEqualityComparer&lt;T&gt;"/> used to compare the key and the child.  If
        /// this is null then the default <see cref="EqualityComparer&lt;T&gt;.Default"/> will be
        /// used.
        /// </param>
        /// <returns>
        /// An <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/> that contains all the
        /// matching children or an empty <see cref="Treenumerable.VirtualTreeEnumerable&lt;T&gt;"/>
        /// if no children match.
        /// </returns>
        public VirtualTreeEnumerable<T> GetChildren(T key, IEqualityComparer<T> comparer)
        {
            return
                this
                .TreeWalker
                .GetChildren(this.Root, key, comparer)
                .ToVirtualTrees(this)
                .AsVirtualTreeEnumerable();
        }
    }
}
