// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//

using Foundation;

namespace ValueConversion.UI.Touch
{
	[Register ("DatesView")]
	partial class DatesView
	{
		[Outlet]
		UIKit.UILabel SimpleDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel TheDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel SimpleOldDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel OldDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel SimpleVeryOldDateLabel { get; set; }

		[Outlet]
		UIKit.UILabel VeryOldDateLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SimpleDateLabel != null) {
				SimpleDateLabel.Dispose ();
				SimpleDateLabel = null;
			}

			if (TheDateLabel != null) {
				TheDateLabel.Dispose ();
				TheDateLabel = null;
			}

			if (SimpleOldDateLabel != null) {
				SimpleOldDateLabel.Dispose ();
				SimpleOldDateLabel = null;
			}

			if (OldDateLabel != null) {
				OldDateLabel.Dispose ();
				OldDateLabel = null;
			}

			if (SimpleVeryOldDateLabel != null) {
				SimpleVeryOldDateLabel.Dispose ();
				SimpleVeryOldDateLabel = null;
			}

			if (VeryOldDateLabel != null) {
				VeryOldDateLabel.Dispose ();
				VeryOldDateLabel = null;
			}
		}
	}
}
