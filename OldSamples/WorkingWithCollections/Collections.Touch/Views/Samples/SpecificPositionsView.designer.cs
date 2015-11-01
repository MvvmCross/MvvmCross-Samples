// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Collections.Touch
{
	[Register ("SpecificPositionsView")]
	partial class SpecificPositionsView
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView SecondImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel SecondLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView FelixImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel FelixLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (SecondImageView != null) {
				SecondImageView.Dispose ();
				SecondImageView = null;
			}

			if (SecondLabel != null) {
				SecondLabel.Dispose ();
				SecondLabel = null;
			}

			if (FelixImageView != null) {
				FelixImageView.Dispose ();
				FelixImageView = null;
			}

			if (FelixLabel != null) {
				FelixLabel.Dispose ();
				FelixLabel = null;
			}
		}
	}
}
