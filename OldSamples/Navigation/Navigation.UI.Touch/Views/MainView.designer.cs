// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Navigation.UI.Touch
{
	[Register ("MainView")]
	partial class MainView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton SimpleButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ParamsButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton AnonButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField KeyTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SimpleButton != null) {
				SimpleButton.Dispose ();
				SimpleButton = null;
			}

			if (ParamsButton != null) {
				ParamsButton.Dispose ();
				ParamsButton = null;
			}

			if (AnonButton != null) {
				AnonButton.Dispose ();
				AnonButton = null;
			}

			if (KeyTextField != null) {
				KeyTextField.Dispose ();
				KeyTextField = null;
			}
		}
	}
}
