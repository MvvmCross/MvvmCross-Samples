// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XPlatformMenus.Mac.Views
{
	[Register ("MainViewController")]
	partial class MainViewController
	{
		[Outlet]
		AppKit.NSView MenuContentView { get; set; }

		[Outlet]
		AppKit.NSPageController PageController { get; set; }

		[Outlet]
		AppKit.NSSplitView SplitView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MenuContentView != null) {
				MenuContentView.Dispose ();
				MenuContentView = null;
			}

			if (PageController != null) {
				PageController.Dispose ();
				PageController = null;
			}

			if (SplitView != null) {
				SplitView.Dispose ();
				SplitView = null;
			}
		}
	}
}
