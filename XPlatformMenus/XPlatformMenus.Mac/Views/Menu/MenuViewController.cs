using System;
using System.Collections.Generic;
using AppKit;
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

			MenuListView.Initialize();
			var menuItems = new SourceListItem("Pages");
			menuItems.AddItem("Home", "home.png", () => { ViewModel.ShowHomeCommand.Execute(); });
			menuItems.AddItem("Help", "help.png", () => { ViewModel.ShowHelpCommand.Execute(); });
			menuItems.AddItem("Settings", "settings.png", () => { ViewModel.ShowSettingCommand.Execute(); });


			// TODO: There is a really odd bug here, if the Window covers the super category "Pages", the buttons
			// will stop working.

			MenuListView.AddItem(menuItems);
			MenuListView.ReloadData();
			MenuListView.ExpandItem(null, true);
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
