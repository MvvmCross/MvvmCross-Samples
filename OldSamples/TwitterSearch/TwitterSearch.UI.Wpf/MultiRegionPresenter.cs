using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.ViewModels;
using System.Linq;
using System.Windows;

namespace TwitterSearch.UI.Wpf
{
    public class MultiRegionPresenter
        : MvxWpfViewPresenter
    {
        private readonly MainWindow _mainWindow;

        public MultiRegionPresenter(MainWindow mainWindow)
        {
            _mainWindow = mainWindow;
        }
        protected override void ShowContentView(FrameworkElement element, MvxContentPresentationAttribute attribute, MvxViewModelRequest request)
        {
            // this is really hacky - do it using attributes isnt
            var region = element
                                .GetType()
                                .GetCustomAttributes(typeof(RegionAttribute), true)
                                .FirstOrDefault() as RegionAttribute;

            var regionName = region == null ? null : region.Name;
            _mainWindow.PresentInRegion(element, regionName);
        }
    }
}