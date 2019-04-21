using MvvmCross.Forms.Platforms.Uap.Core;
using MvvmCross.Forms.Platforms.Uap.Views;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;

namespace StarWarsSample.Forms.UWP
{
    public sealed partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs activationArgs)
        {
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            OxyPlot.Xamarin.Forms.Platform.UWP.PlotViewRenderer.Init();

            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = false;

            base.OnLaunched(activationArgs);
        }
    }

    public abstract class StarWarsSampleApp : MvxWindowsApplication<MvxFormsWindowsSetup<Core.App, Forms.App>, Core.App, Forms.App, MainPage>
    {
    }
}
