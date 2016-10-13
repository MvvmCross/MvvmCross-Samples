using AppKit;
using Foundation;
using MvvmCross.Mac.Platform;
using MvvmCross.Mac.Views.Presenters;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using CoreGraphics;

namespace TipCalc.UI.Mac
{
	[Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate
	{
		public NSWindow Window { get; set; }

		public override void DidFinishLaunching(NSNotification notification)
		{
			Window = new NSWindow(new CGRect(0, 0, 400, 300),
					  NSWindowStyle.Titled | NSWindowStyle.Resizable | NSWindowStyle.Closable,
					  NSBackingStore.Buffered, false, NSScreen.MainScreen);        // how big?
			Window.Title = "TipCalc";
			Window.WillClose += (sender, e) =>
			{
				NSApplication.SharedApplication.Terminate(this);
			};

			var presenter = new MvxMacViewPresenter(this, Window);

			var setup = new Setup(this, presenter);
			setup.Initialize();

			var startup = Mvx.Resolve<IMvxAppStart>();
			startup.Start();

			Window.MakeKeyAndOrderFront(this);
		}

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}

