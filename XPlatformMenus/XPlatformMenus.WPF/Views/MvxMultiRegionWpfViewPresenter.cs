using MvvmCross.Wpf.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MvvmCross.Core.ViewModels;
using System.Windows;
using MvvmCross.Platform;
using System.Windows.Media;
using MvvmCross.Core.Views;

namespace XPlatformMenus.WPF.Views
{
    public class MvxMultiRegionWpfViewPresenter : MvxSimpleWpfViewPresenter
    {
        private readonly ContentControl _contentControl;

        public MvxMultiRegionWpfViewPresenter(ContentControl contentControl)
            : base(contentControl)
        {
            _contentControl = contentControl;
        }

        public override void Show(MvxViewModelRequest request)
        {
            var viewType = GetViewType(request);

            if (viewType.HasRegionAttribute())
            {
                var loader = Mvx.Resolve<IMvxSimpleWpfViewLoader>();
                var view = loader.CreateView(request);

                var containerView = FindChild<Frame>(_contentControl, viewType.GetRegionName());

                if (containerView != null)
                {
                    containerView.Navigate(view);
                    return;
                }
            }
            
            base.Show(request);
        }

        private static Type GetViewType(MvxViewModelRequest request)
        {
            var viewFinder = Mvx.Resolve<IMvxViewsContainer>();
            return viewFinder.GetViewType(request.ViewModelType);
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            // deal with popToRoot
            base.ChangePresentation(hint);
        }

        // Implementation from: http://stackoverflow.com/a/1759923/80186
        internal static T FindChild<T>(DependencyObject reference, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid.
            if (reference == null) return null;

            var foundChild = default(T);
            var nextPhase = new List<DependencyObject>();

            var childrenCount = VisualTreeHelper.GetChildrenCount(reference);
            for (var index = 0; index < childrenCount; index++)
            {
                var child = VisualTreeHelper.GetChild(reference, index);

                // If the child is not of the request child type child
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(child, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        // if the child's name is of the request name
                        foundChild = (T)child;
                        break;
                    }
                    else
                    {
                        // keep for searching inside this frame
                        nextPhase.Add(child);
                    }
                }
                else
                {
                    // child element found.
                    foundChild = (T)child;
                    break;
                }
            }

            // if failed to find the child, search inside the frames we found
            if (foundChild == null)
            {
                foreach (var item in nextPhase)
                {
                    // recursively drill down the tree
                    foundChild = FindChild<T>(item, childName);

                    // If the child is found, break so we do not overwrite the found child. 
                    if (foundChild != null) break;

                }
            }

            return foundChild;
        }
    }
}
