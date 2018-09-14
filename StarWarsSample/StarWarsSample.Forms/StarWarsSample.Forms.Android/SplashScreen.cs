using System.Threading.Tasks;
using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Views;

namespace StarWarsSample.Forms.Droid
{
    [Activity(
        Label = "StarWarsSample.Forms",
        MainLauncher = true,
        Icon = "@mipmap/icon",
        Theme = "@style/MainTheme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashScreen : MvxFormsSplashScreenActivity<Setup, Core.App, App>
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }

        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(RootActivity));
            return Task.CompletedTask;
        }
    }
}