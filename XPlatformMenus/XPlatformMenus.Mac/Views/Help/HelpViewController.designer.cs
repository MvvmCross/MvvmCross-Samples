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
	[Register ("HelpViewController")]
	partial class HelpViewController
	{
		[Outlet]
		AppKit.NSTextField HelpLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (HelpLabel != null) {
				HelpLabel.Dispose ();
				HelpLabel = null;
			}
		}
	}
}
