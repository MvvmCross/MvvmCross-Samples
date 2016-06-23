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
		AppKit.NSPageController MenuContentPageController { get; set; }

		[Outlet]
		AppKit.NSPageController PageContentPageController { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MenuContentPageController != null) {
				MenuContentPageController.Dispose ();
				MenuContentPageController = null;
			}

			if (PageContentPageController != null) {
				PageContentPageController.Dispose ();
				PageContentPageController = null;
			}
		}
	}
}
