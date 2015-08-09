using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Gets a this <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> leaves, i.e. all
        /// descendants that do not have children.  If the this 
        /// <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> has no children then this is returned.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;VirtualTree&lt;T&gt;&gt;"/>
        /// that contains all the leaves.
        /// </returns>
        public IEnumerable<VirtualTree<T>> GetLeaves()
        {
            return
                this
                .TreeWalker
                .GetLeaves(this.Root)
                .ToVirtualTrees(this);
        }
    }
}
