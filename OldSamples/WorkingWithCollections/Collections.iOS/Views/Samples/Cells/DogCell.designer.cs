// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;

namespace Collections.Touch
{
	partial class DogCell
	{
		[Outlet]
		UIKit.UILabel MainLabel { get; set; }

		[Outlet]
		UIKit.UIImageView DogImageView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MainLabel != null) {
				MainLabel.Dispose ();
				MainLabel = null;
			}

			if (DogImageView != null) {
				DogImageView.Dispose ();
				DogImageView = null;
			}
		}
	}
}
