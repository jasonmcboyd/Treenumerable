using System.Linq;

namespace Treenumerable
{
    public partial struct VirtualTree<T>
    {
        public VirtualTree<T> GetParentOrDefault()
        {
            return this.GetAncestors().FirstOrDefault();
        }
    }
}
