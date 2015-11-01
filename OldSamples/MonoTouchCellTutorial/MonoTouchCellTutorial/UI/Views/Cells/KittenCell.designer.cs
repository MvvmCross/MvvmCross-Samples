// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MonoTouchCellTutorial
{
	partial class KittenCell
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView KittenImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel NameLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel PriceLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel LitterTrainedLabel { get; set; }

		[Action ("IncreasePriceAction:")]
		partial void IncreasePriceAction (MonoTouch.Foundation.NSObject sender);

		[Action ("DecreasePriceAction:")]
		partial void DecreasePriceAction (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (KittenImageView != null) {
				KittenImageView.Dispose ();
				KittenImageView = null;
			}

			if (NameLabel != null) {
				NameLabel.Dispose ();
				NameLabel = null;
			}

			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}

			if (LitterTrainedLabel != null) {
				LitterTrainedLabel.Dispose ();
				LitterTrainedLabel = null;
			}
		}
	}
}
