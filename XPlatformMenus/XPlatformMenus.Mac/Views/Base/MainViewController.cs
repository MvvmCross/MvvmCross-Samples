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
			if (PageController.ArrangedObjects.Count() > 0)
			{
				PageController.SelectedIndex = 0;
				PageController.ArrangedObjects = new NSObject[] { PageController.ArrangedObjects.First() };
			}
		}

		public void PlaceView(string region, NSView targetView)
		{
			NSView containerView = null;

			switch (region)
			{
				case "MenuContent":
					containerView = MenuContentView;
					break;
				case "PageContent":
					if (PageController.ArrangedObjects.Any())
					{
						PageController.NavigateForwardTo(targetView);
						return;
					}
					containerView = PageController.View;
					PageController.NavigateForwardTo(targetView);
					break;
			}

			if (containerView != null)
			{
				containerView.SwapSubView(targetView);
			}
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			PageController.Delegate = new PageControllerDelegate();
			SplitView.Delegate = new SplitViewDelegate();

			/*
  			SplitView.TranslatesAutoresizingMaskIntoConstraints = false;
			var containerView = View;
			var targetView = SplitView;
			NSDictionary views = NSDictionary.FromObjectAndKey(targetView, new NSString("target"));
			containerView.AddConstraints(NSLayoutConstraint.FromVisualFormat(
				"H:|[target]|", NSLayoutFormatOptions.None, null, views));
			containerView.AddConstraints(NSLayoutConstraint.FromVisualFormat(
				"V:|[target]|", NSLayoutFormatOptions.None, null, views));
				*/
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
