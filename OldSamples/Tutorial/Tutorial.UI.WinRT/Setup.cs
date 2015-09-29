using Cirrious.MvvmCross.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Tutorial.UI.WinRT
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
            var app = new Tutorial.Core.App();
            return app;
        }
    }
}