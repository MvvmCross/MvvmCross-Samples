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
//            var presenter = new MvxSimpleWpfViewPresenter(MainWindow);
            var presenter = new MvxMultiRegionWpfViewPresenter(MainWindow);

            var setup = new Setup(Dispatcher, presenter);
            setup.Initialize();

            // Q: Why do we even have to do this, doesn't MvvmCross normally find the matching
            // viewModel to view relationship?
            Mvx.RegisterSingleton<IMvxWpfViewsContainer>(() => new MvxWpfViewsContainer());
            var viewsContainer = Mvx.Resolve<IMvxWpfViewsContainer>();
            viewsContainer.Add<LoginViewModel, LoginView>();
            viewsContainer.Add<MainViewModel, MainView>();
            viewsContainer.Add<HelpAndFeedbackViewModel, HelpView>();
            viewsContainer.Add<SettingsViewModel, SettingsView>();
            viewsContainer.Add<HomeViewModel, HomeView>();
            viewsContainer.Add<InfoViewModel, InfoView>();
            viewsContainer.Add<ThirdViewModel, ThirdView>();

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
