using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Core.ViewModels;
using XPlatformMenus.Core;
using XPlatformMenus.Core.Interfaces;
using MvvmCross.Platform;
using XPlatformMenus.Mac.Services;
using AppKit;
using XPlatformMenus.Mac.Views;

namespace XPlatformMenus.Mac
{
	public class Setup : MvxMacSetup
	{
		public Setup(MvxApplicationDelegate appDelegate, NSWindow window)
			: base(appDelegate, window)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new App();
		}

		protected override IMvxMacViewPresenter CreatePresenter()
		{
			return new CustomViewPresenter(ApplicationDelegate, Window);
		}

		protected override void InitializeFirstChance()
		{
			base.InitializeFirstChance();

			Mvx.RegisterSingleton<IDialogService>(() => new MacDialogService());
			Mvx.RegisterSingleton<MvxPresentationHint>(() => new MvxPanelPopToRootPresentationHint());
		}
	}
}
