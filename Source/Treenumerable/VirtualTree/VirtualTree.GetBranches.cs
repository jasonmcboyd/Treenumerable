using System.Collections.Generic;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Returns the children of the <see cref="VirtualTree&lt;T&gt;"/>; a branch being a path
        /// from the root node to a leaf node.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Collections.Generic.IEnumerable&lt;Treenumerable.VirtualTreeEnumerable&lt;T&gt;&gt;"/>
        /// that contains all the branches.
        /// </returns>
        public IEnumerable<IList<T>> GetBranches()
        {
            var branches =
                this
                .TreeWalker
                .GetBranches(this.Root);

            foreach (var branch in branches)
            {
                yield return branch;
            }
        }
    }
}
