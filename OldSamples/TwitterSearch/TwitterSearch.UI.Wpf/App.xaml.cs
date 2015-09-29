using Cirrious.MvvmCross.ViewModels;
using System.Windows;

namespace TwitterSearch.UI.Wpf
{
    public partial class App
        : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();
        }
    }
}