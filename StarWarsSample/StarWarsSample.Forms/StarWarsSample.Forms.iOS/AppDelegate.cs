using FFImageLoading.Forms.Platform;
using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;
using OxyPlot.Xamarin.Forms.Platform.iOS;
using UIKit;

namespace StarWarsSample.Forms.iOS
{
    [Register(nameof(AppDelegate))]
    public partial class AppDelegate : MvxFormsApplicationDelegate<Setup, Core.App, UI.App>
    {
        public override bool FinishedLaunching(UIApplication uiApplication, NSDictionary launchOptions)
        {
            CachedImageRenderer.Init();
            PlotViewRenderer.Init();

            return base.FinishedLaunching(uiApplication, launchOptions);
        }
    }
}