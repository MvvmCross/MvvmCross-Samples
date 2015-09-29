// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace Collections.Touch
{
	partial class KittenCell
	{
		[Outlet]
		MonoTouch.UIKit.UILabel MainLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView KittenImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MainLabel != null) {
				MainLabel.Dispose ();
				MainLabel = null;
			}

			if (KittenImageView != null) {
				KittenImageView.Dispose ();
				KittenImageView = null;
			}
		}
	}
}
