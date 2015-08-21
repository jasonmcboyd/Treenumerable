using System.Collections.Generic;

namespace Treenumerable
{
    public static partial class TreeWalkerExtensions
    {
        /// <summary>
        /// Tries to get the child at the specified index.
        /// </summary>
        /// <typeparam name="T">The type of elements in the tree.</typeparam>
        /// <param name="walker">
        /// The <see cref="ITreeWalker&lt;T&gt;"/> that knows how to find the parent and child
        /// nodes.
        /// </param>
        /// <param name="nodes">The nodes whose children are to be returned.</param>
        /// <param name="index">The index of the child to retrieve.</param>
        /// <param name="child">
        /// The child that was found at the specified index or a default value if the index was
        /// out of range.
        /// </param>
        /// <returns>
        /// True, if a child was found at the specified index; false, otherwise.
        /// </returns>
        internal static bool TryGetChildAt<T>(
            this ITreeWalker<T> walker, 
            T node, 
            int index, 
            out T child)
        {
            // Performance optimization.  Checking to see if the result from GetChildren returns
            // an IList.  If it does then we can simply get the child using the list's indexer
            // property.
            IList<T> list = walker.GetChildren(node) as IList<T>;
            if (list != null)
            {
                // If the index is within bounds then get the child an return true.
                if (index < list.Count)
                {
                    child = list[index];
                    return true;
                }
            }
            else
            {
                // Iterate over each child, decrementing the index while doing so.
                // If the index reaches 0 then we have found the child.
                // Get the child and return true.
                using (IEnumerator<T> enumerator = walker.GetChildren(node).GetEnumerator())
                {
                    while (index >= 0 && enumerator.MoveNext())
                    {
                        index--;
                    }
                    if (index == -1)
                    {
                        child = enumerator.Current;
                        return true;
                    }
                }
            }

            // If no child was found then return false.
            child = default(T);
            return false;
        }
    }
}
