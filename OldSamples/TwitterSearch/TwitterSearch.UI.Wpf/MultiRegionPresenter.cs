using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.ViewModels;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace TwitterSearch.UI.Wpf
{
    public class MultiRegionPresenter
        : MvxWpfViewPresenter
    {
        private readonly ContentControl _root;

        public MultiRegionPresenter(ContentControl root)
        {
            _root = root;
        }
        protected override void ShowContentView(FrameworkElement element, MvxContentPresentationAttribute attribute, MvxViewModelRequest request)
        {
            // this is really hacky - do it using attributes isnt
            var region = element
                                .GetType()
                                .GetCustomAttributes(typeof(RegionAttribute), true)
                                .FirstOrDefault() as RegionAttribute;

            var regionName = region == null ? null : region.Name;

            if (_root is MainWindow)
            {
                var mainWindow = _root as MainWindow;
                mainWindow.PresentInRegion(element, regionName);
            }
            else
            {
                base.ShowContentView(element, attribute, request);
            }
        }
    }
}