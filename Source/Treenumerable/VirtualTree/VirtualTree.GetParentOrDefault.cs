using System.Linq;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        /// <summary>
        /// Returns the parent or a default <see cref="Treenumerable.VirtualTree&lt;T&gt;"/> if no
        /// parent exists.
        /// </summary>
        /// <returns>The parent.</returns>
        public VirtualTree<T> GetParentOrDefault()
        {
            return this.GetAncestors().FirstOrDefault();
        }
    }
}
