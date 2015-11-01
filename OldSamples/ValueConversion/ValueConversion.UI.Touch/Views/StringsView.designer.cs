// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace ValueConversion.UI.Touch
{
	[Register ("StringsView")]
	partial class StringsView
	{
		[Outlet]
		MonoTouch.UIKit.UILabel ReversedLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LengthLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField TextEditor { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (ReversedLabel != null) {
				ReversedLabel.Dispose ();
				ReversedLabel = null;
			}

			if (LengthLabel != null) {
				LengthLabel.Dispose ();
				LengthLabel = null;
			}

			if (TextEditor != null) {
				TextEditor.Dispose ();
				TextEditor = null;
			}
		}
	}
}
