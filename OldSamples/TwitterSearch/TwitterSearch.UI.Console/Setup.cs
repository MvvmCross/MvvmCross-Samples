using Cirrious.MvvmCross.ViewModels;
using TwitterSearch.Core;

namespace TwitterSearch.UI.Console
{
    public class Setup
        : MvxConsoleSetup
    {
        protected override IMvxApplication CreateApp()
        {
            var app = new TwitterSearchApp();
            return app;
        }
    }
}