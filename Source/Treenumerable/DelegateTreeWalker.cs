using System;
using System.Collections.Generic;

namespace Treenumerable
{
    public class DelegateTreeWalker<T> : ITreeWalker<T>
    {
        public DelegateTreeWalker(
            Func<T, ParentNode<T>> getParentFunc,
            Func<T, IEnumerable<T>> getChildrenFunc)
        {
            if (getParentFunc == null)
            {
                throw new ArgumentNullException("getParentFunc");
            }

            if (getChildrenFunc == null)
            {
                throw new ArgumentNullException("getChildrenFunc");
            }

            this._GetParentFunc = getParentFunc;
            this._GetChildrenFunc = getChildrenFunc;
        }

        private readonly Func<T, ParentNode<T>> _GetParentFunc;
        private readonly Func<T, IEnumerable<T>> _GetChildrenFunc;

        public ParentNode<T> GetParentNode(T node)
        {
            return this._GetParentFunc.Invoke(node);
        }

        public IEnumerable<T> GetChildren(T node)
        {
            return this._GetChildrenFunc.Invoke(node);
        }
    }
}
