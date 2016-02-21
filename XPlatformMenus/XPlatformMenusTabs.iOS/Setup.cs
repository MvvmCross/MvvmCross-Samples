using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using UIKit;
using XPlatformMenus.Core.Interfaces;
using XPlatformMenusTabs.iOS.Interfaces;
using XPlatformMenusTabs.iOS.Presenter;
using XPlatformMenusTabs.iOS.Services;

namespace XPlatformMenusTabs.iOS
{
    public class Setup : MvxIosSetup
    {
        private MvxApplicationDelegate _applicationDelegate;
        private UIWindow _window;

        /// <summary>Initializes a new instance of the <see cref="Setup"/> class.</summary>
        /// <param name="applicationDelegate">The application delegate.</param>
        /// <param name="window">The window.</param>
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
            _applicationDelegate = applicationDelegate;
            _window = window;
        }

        /// <summary>Creates the application.</summary>
        /// <returns>The IMvxApplication <see langword="object"/></returns>
        protected override IMvxApplication CreateApp()
        {
            return new XPlatformMenus.Core.App();
        }

        /// <summary>Creates the debug trace.</summary>
        /// <returns>The IMvxTrace <see langword="object"/></returns>
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            var mvxIosViewPresenter = new MvxTabPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
            Mvx.RegisterSingleton<ITabBarPresenterHost>(mvxIosViewPresenter);
            return mvxIosViewPresenter;
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<IDialogService>(() => new TouchDialogService());
        }
    }
}
