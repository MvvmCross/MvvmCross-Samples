using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using MvvmCross.WindowsUWP.Platform;
using MvvmCross.WindowsUWP.Views;
using Windows.UI.Xaml.Controls;
using XPlatformMenus.Core.Interfaces;
using XPlatformMenus.UWP.Services;
using XPlatformMenus.UWP.Views;

namespace XPlatformMenus.UWP
{
    public class Setup : MvxWindowsSetup
	{
		public Setup(Frame rootFrame) : base(rootFrame)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new Core.App();
		}

		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}

		protected override IMvxWindowsViewPresenter CreateViewPresenter(IMvxWindowsFrame rootFrame)
		{
			return new CustomViewPresenter(rootFrame);
		}

		protected override void InitializeFirstChance()
		{
			base.InitializeFirstChance();

			Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
            Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
        }
    }
}
