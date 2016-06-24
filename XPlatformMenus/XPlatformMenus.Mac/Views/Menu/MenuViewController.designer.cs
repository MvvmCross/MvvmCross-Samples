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
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		AppKit.NSButton HelpButton { get; set; }

		[Outlet]
		AppKit.NSButton HomeButton { get; set; }

		[Outlet]
		AppKit.NSOutlineView MenuOutlineView { get; set; }

		[Outlet]
		AppKit.NSButton SettingsButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (HelpButton != null) {
				HelpButton.Dispose ();
				HelpButton = null;
			}

			if (HomeButton != null) {
				HomeButton.Dispose ();
				HomeButton = null;
			}

			if (SettingsButton != null) {
				SettingsButton.Dispose ();
				SettingsButton = null;
			}

			if (MenuOutlineView != null) {
				MenuOutlineView.Dispose ();
				MenuOutlineView = null;
			}
		}
	}
}
