// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MonoTouchCellTutorial
{
	partial class DogCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView DogImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PriceLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel GoodWithChildrenLabel { get; set; }

		[Action ("DeleteButtonAction:")]
		partial void DeleteButtonAction (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (DogImageView != null) {
				DogImageView.Dispose ();
				DogImageView = null;
			}

			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (GoodWithChildrenLabel != null) {
				GoodWithChildrenLabel.Dispose ();
				GoodWithChildrenLabel = null;
			}
		}
	}
}
