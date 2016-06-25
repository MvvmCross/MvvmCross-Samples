// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XPlatformMenus.Mac.Views
{
	[Register ("MenuViewController")]
	partial class MenuViewController
	{
		[Outlet]
		XPlatformMenus.Mac.Views.SourceListView MenuListView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MenuListView != null) {
				MenuListView.Dispose ();
				MenuListView = null;
			}
		}
	}
}
