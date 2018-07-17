using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.ViewModels;
using System.Windows.Controls;
using System.Windows.Threading;
using TwitterSearch.Core;

namespace TwitterSearch.UI.Wpf
{
    public class Setup
        : MvxWpfSetup
    {
        protected override IMvxWpfViewPresenter CreateViewPresenter(ContentControl root)
        {
            return new MultiRegionPresenter(root);
        }
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}