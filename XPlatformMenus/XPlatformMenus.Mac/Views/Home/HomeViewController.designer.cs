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
	[Register ("HomeViewController")]
	partial class HomeViewController
	{
		[Outlet]
		AppKit.NSButton ShowInfoButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ShowInfoButton != null) {
				ShowInfoButton.Dispose ();
				ShowInfoButton = null;
			}
		}
	}
}
