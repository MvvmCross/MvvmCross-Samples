using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using AppKit;
using MvvmCross.Mac.Views;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Mac.Views
{
	public partial class MainViewController : BaseViewController<MainViewModel>
	{
		#region Constructors

		// Called when created from unmanaged code
		public MainViewController(IntPtr handle) : base(handle)
		{
			Initialize();
		}

		// Called when created directly from a XIB file
		[Export("initWithCoder:")]
		public MainViewController(NSCoder coder) : base(coder)
		{
			Initialize();
		}

		// Call to load from the XIB/NIB file
		public MainViewController() : base("MainView", NSBundle.MainBundle)
		{
			Initialize();
		}

		// Shared initialization code
		void Initialize()
		{
		}

		#endregion

		// https://developer.apple.com/reference/appkit/nspagecontroller

		public void PopToRoot()
		{
			// TODO: while we can navigate back
		}

		public void PlaceView(string region, NSView view)
		{
			switch (region)
			{
				case "MenuContent":
					// probably a PageController is not needed here
					while (MenuContentView.Subviews.Any())
					{
						MenuContentView.Subviews[0].RemoveFromSuperview();
					}
					MenuContentView.AddSubview(view);
					break;
				case "PageContent":
					PageContentPageController.NavigateForwardTo(NSObject.FromObject(view.GetType().ToString()));
					while (PageContentPageController.View.Subviews.Any())
					{
						PageContentPageController.View.Subviews[0].RemoveFromSuperview();
					}
					PageContentPageController.View.AddSubview(view);
					break;
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
		}

		public override void ViewDidAppear()
		{
			base.ViewDidAppear();

			ViewModel.ShowMenu();
		}

		//strongly typed view accessor
		public new MainView View
		{
			get
			{
				return (MainView)base.View;
			}
		}
	}
}
