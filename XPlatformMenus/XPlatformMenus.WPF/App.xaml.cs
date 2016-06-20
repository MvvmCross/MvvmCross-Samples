using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Wpf.Views;
using System.Windows;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.WPF.Views;

namespace XPlatformMenus.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        bool _setupComplete;

        void DoSetup()
        {
            var presenter = new MvxSimpleWpfViewPresenter(MainWindow);

            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            //Mvx.RegisterSingleton<IMvxWpfViewsContainer>(() => new MvxWpfViewsContainer());
            //var viewsContainer = Mvx.Resolve<IMvxWpfViewsContainer>();
            //viewsContainer.Add<LoginViewModel, LoginView>();

            var start = Mvx.Resolve<IMvxAppStart>();
            start.Start();

            _setupComplete = true;
        }

        protected override void OnActivated(System.EventArgs e)
        {
            if (!_setupComplete)
                DoSetup();

            base.OnActivated(e);
        }
    }
}
