using System;
using Foundation;
using MvvmCross.Binding.BindingContext;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	[MvxRegion("MenuContent")]
	public partial class MenuViewController : BaseViewController<MenuViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public MenuViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MenuViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public MenuViewController() : base("MenuView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			var set = this.CreateBindingSet<MenuViewController, MenuViewModel>();
			set.Bind(HomeButton).To(vm => vm.ShowHomeCommand);
			set.Bind(HelpButton).To(vm => vm.ShowHelpCommand);
			set.Bind(SettingsButton).To(vm => vm.ShowSettingCommand);
			set.Apply();
		}

		//strongly typed view accessor
		public new MenuView View
		{
			get
			{
				return (MenuView)base.View;
			}
		}
	}
}
