using Foundation;
using AppKit;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Core.ViewModels;
using CoreGraphics;
using MvvmCross.Platform;

namespace FirstDemo.Mac
{
	public partial class AppDelegate : MvxApplicationDelegate
	{
		NSWindow _window;

		public AppDelegate()
		{
		}

		public override void DidFinishLaunching(NSNotification notification)
		{
			_window = new NSWindow (new CGRect(200,200,400,400), NSWindowStyle.Closable | NSWindowStyle.Resizable | NSWindowStyle.Titled,
			                        NSBackingStore.Buffered, false, NSScreen.MainScreen);

			var presenter = new MvxMacViewPresenter (this);
			var setup = new Setup (this, presenter);
			setup.Initialize ();

			var startup = Mvx.Resolve<IMvxAppStart> ();
			startup.Start ();

			_window.MakeKeyAndOrderFront (this);

			return;
		}
	}
}

