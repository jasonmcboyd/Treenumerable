using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Treenumerable.Wpf
{
    public class VisualTreeWalker : ITreeWalker<DependencyObject>
    {
        private VisualTreeWalker()
        {
            // Hide the default public constructor.
        }

        private static readonly VisualTreeWalker _Instance = new VisualTreeWalker();
        public static VisualTreeWalker Instance
        {
            get { return VisualTreeWalker._Instance; }
        }

        public ParentNode<DependencyObject> GetParentNode(DependencyObject node)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(node);
            return parent != null ? ParentNode.Create(parent) : default(ParentNode<DependencyObject>);
        }

        public IEnumerable<DependencyObject> GetChildren(DependencyObject node)
        {
            int count = VisualTreeHelper.GetChildrenCount(node);
            for (int i = 0; i < count; i++)
            {
                yield return VisualTreeHelper.GetChild(node, i);
            }
        }
    }
}
