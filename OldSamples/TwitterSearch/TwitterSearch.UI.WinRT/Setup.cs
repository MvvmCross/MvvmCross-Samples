using Cirrious.MvvmCross.ViewModels;
using TwitterSearch.Core;
using Windows.UI.Xaml.Controls;

namespace TwitterSearch.UI.WinRT
{
    public class Setup
        : MvxStoreSetup
    {
        public Setup(Frame rootFrame)
            : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var app = new TwitterSearchApp();
            return app;
        }
    }
}