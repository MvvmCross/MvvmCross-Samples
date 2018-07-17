using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
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
            if (_root is MainWindow && element is MvxWpfView)
            {
                var mainWindow = _root as MainWindow;
                // this is really hacky - do it using attributes isnt
                mainWindow.PresentInRegion(element, attribute);
            }
        }
    }
}