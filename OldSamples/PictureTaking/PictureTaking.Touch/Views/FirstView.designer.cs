// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace PictureTaking.Touch
{
	[Register ("FirstView")]
	partial class FirstView
	{
		[Outlet]
		MonoTouch.UIKit.UIButton TakeButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton ChooseButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView PictureImage { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TakeButton != null) {
				TakeButton.Dispose ();
				TakeButton = null;
			}

			if (ChooseButton != null) {
				ChooseButton.Dispose ();
				ChooseButton = null;
			}

			if (PictureImage != null) {
				PictureImage.Dispose ();
				PictureImage = null;
			}
		}
	}
}
