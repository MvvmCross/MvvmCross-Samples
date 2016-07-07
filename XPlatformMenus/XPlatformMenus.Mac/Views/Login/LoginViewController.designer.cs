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
	[Register ("LoginViewController")]
	partial class LoginViewController
	{
		[Outlet]
		AppKit.NSButton LoginButton { get; set; }

		[Outlet]
		AppKit.NSSecureTextField PasswordSecureTextField { get; set; }

		[Outlet]
		AppKit.NSTextField UsernameTextField { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (UsernameTextField != null) {
				UsernameTextField.Dispose ();
				UsernameTextField = null;
			}

			if (PasswordSecureTextField != null) {
				PasswordSecureTextField.Dispose ();
				PasswordSecureTextField = null;
			}

			if (LoginButton != null) {
				LoginButton.Dispose ();
				LoginButton = null;
			}
		}
	}
}
