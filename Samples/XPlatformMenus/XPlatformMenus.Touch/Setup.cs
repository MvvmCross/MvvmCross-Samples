using UIKit;
using XPlatformMenus.Core.Interfaces;
using XPlatformMenus.Touch.Panels;
using XPlatformMenus.Touch.Services;
using MvvmCross.iOS.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.iOS.Views.Presenters;

namespace XPlatformMenus.Touch
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
            return new Core.App();
        }

        /// <summary>Creates the debug trace.</summary>
        /// <returns>The IMvxTrace <see langword="object"/></returns>
        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            return new JaSidePanelsMvxPresenter((MvxApplicationDelegate)ApplicationDelegate, Window);
        }

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<IDialogService>(() => new TouchDialogService());
        }
	}
}
