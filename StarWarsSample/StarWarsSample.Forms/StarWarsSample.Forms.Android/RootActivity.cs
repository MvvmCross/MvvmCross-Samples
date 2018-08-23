using Acr.UserDialogs;
using Android.App;
using Android.Content.PM;
using Android.OS;
using FFImageLoading.Forms.Platform;
using Lottie.Forms.Droid;
using MvvmCross.Forms.Platforms.Android.Views;
using OxyPlot.Xamarin.Forms.Platform.Android;

namespace StarWarsSample.Forms.Droid
{
    [Activity(
        Label = "StarWarsSample.Forms",
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme",
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class RootActivity : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            AnimationViewRenderer.Init();
            PlotViewRenderer.Init();
            CachedImageRenderer.Init(true);
            UserDialogs.Init(this);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}

