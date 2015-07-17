using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        public static VirtualTreeEnumerable<T> AsVirtualTreeEnumerable<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees)
        {
            VirtualTreeEnumerable<T> vte = virtualTrees as VirtualTreeEnumerable<T>;
            if (vte != null)
            {
                return vte;
            }
            else
            {
                return new VirtualTreeEnumerable<T>(virtualTrees);
            }
        }
    }
}
