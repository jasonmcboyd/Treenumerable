using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class EnumerableOfVirtualTreeExtensions
    {
        public static IEnumerable<T> Unwrap<T>(this IEnumerable<VirtualTree<T>> virtualTrees)
        {
            foreach (VirtualTree<T> tree in virtualTrees)
            {
                yield return tree.Root;
            }
        }
    }
}
