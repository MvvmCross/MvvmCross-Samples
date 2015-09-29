using Cirrious.MvvmCross.ViewModels;
using Windows.UI.Xaml.Controls;

namespace Navigation.UI.WindowsStore
{
    public class Setup : MvxStoreSetup
    {
        public Setup(Frame rootFrame)
            : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }
    }
}