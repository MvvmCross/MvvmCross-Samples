// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace ValueConversion.UI.Touch
{
	[Register ("VisibilityView")]
	partial class VisibilityView
	{
		[Outlet]
		UIKit.UIView TheThing { get; set; }

		[Outlet]
		UIKit.UISwitch ShowSwitch { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TheThing != null) {
				TheThing.Dispose ();
				TheThing = null;
			}

			if (ShowSwitch != null) {
				ShowSwitch.Dispose ();
				ShowSwitch = null;
			}
		}
	}
}
