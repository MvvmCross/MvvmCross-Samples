using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.ViewModels;
using System.Windows.Threading;
using TwitterSearch.Core;

namespace TwitterSearch.UI.Wpf
{
    public class Setup
        : MvxWpfSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new TwitterSearchApp();
        }
    }
}