using System.Collections.Generic;
using System.Linq;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        public static VirtualTreeEnumerable<T> GetChildAtOrDefault<T>(
            this IEnumerable<VirtualTree<T>> virtualTrees,
            int index)
        {
            return
                virtualTrees
                .Select(x => x.GetChildAtOrDefault(index))
                .AsVirtualTreeEnumerable();
        }
    }
}
