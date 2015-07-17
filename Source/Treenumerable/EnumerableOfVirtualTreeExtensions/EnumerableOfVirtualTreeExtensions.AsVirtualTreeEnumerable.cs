using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        public static VirtualTreeEnumerable<T> AsVirtualTreeEnumerable<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees)
        {
            return new VirtualTreeEnumerable<T>(virtualTrees);
        }
    }
}
