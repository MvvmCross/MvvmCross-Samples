using AppKit;
using Foundation;
using CoreGraphics;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using System.Linq;

namespace XPlatformMenus.Mac
{
	[Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
	{
		private NSWindow _window;

		public override void DidFinishLaunching(NSNotification notification)
		{
			// Borrow window from the main storyboard
			_window = NSApplication.SharedApplication.Windows.First();
			_window.WillClose += (sender, e) =>
			{
				NSApplication.SharedApplication.Terminate(this);
			};

			var setup = new Setup(this, _window);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			_window.MakeKeyAndOrderFront(this);		}

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}

