using MvvmCross.ViewModels;
using TwitterSearch.Core;
using MvvmCross.Platforms.Console.Core;
using MvvmCross.Logging;

namespace TwitterSearch.UI.Console
{
    public class Setup
        : MvxConsoleSetup
    {
        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}