using AppKit;
using Foundation;
using MvvmCross.Platforms.Mac.Core;

namespace TipCalc.UI.Mac
{
    [Register("AppDelegate")]
	public class AppDelegate : MvxApplicationDelegate<Setup, Core.App>
	{
		public NSWindow Window { get; set; }

		public override void DidFinishLaunching(NSNotification notification)
		{
			MvxMacSetupSingleton.EnsureSingletonAvailable(this).EnsureInitialized();
			RunAppStart();
		}

		public override void WillTerminate(NSNotification notification)
		{
			// Insert code here to tear down your application
		}
	}
}

