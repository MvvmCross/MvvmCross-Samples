// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace ValueConversion.UI.Touch
{
	[Register ("TwoWayView")]
	partial class TwoWayView
	{
		[Outlet]
		UIKit.UITextField TheTextField { get; set; }

		[Outlet]
		UIKit.UILabel TheLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TheTextField != null) {
				TheTextField.Dispose ();
				TheTextField = null;
			}

			if (TheLabel != null) {
				TheLabel.Dispose ();
				TheLabel = null;
			}
		}
	}
}
