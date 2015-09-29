// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace MonoTouchCellTutorial
{
	[Register ("PetShopView")]
	partial class PetShopView
	{
		[Outlet]
		MonoTouch.UIKit.UITableView TableView { get; set; }

		[Action ("OnAddAnimalsClick:")]
		partial void OnAddAnimalsClick (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (TableView != null) {
				TableView.Dispose ();
				TableView = null;
			}
		}
	}
}
