// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace InternetMinute.Touch
{
	[Register ("DescriptionCell")]
	partial class DescriptionCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView MainImage { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel CountLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MainImage != null) {
				MainImage.Dispose ();
				MainImage = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (CountLabel != null) {
				CountLabel.Dispose ();
				CountLabel = null;
			}
		}
	}
}
