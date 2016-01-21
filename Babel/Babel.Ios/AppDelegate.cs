using Foundation;
using UIKit;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using Babel.Touch;

namespace Babel.Ios
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : MvxApplicationDelegate
	{
		private UIWindow _window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			_window = new UIWindow (UIScreen.MainScreen.Bounds);

			var setup = new Setup (this, _window);
			setup.Initialize ();

			var startup = Mvx.Resolve<IMvxAppStart> ();
			startup.Start ();

			_window.MakeKeyAndVisible ();

			return true;
		}
	}
}