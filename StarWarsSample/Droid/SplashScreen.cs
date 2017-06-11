using Android;
using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace StarWarsSample.Droid
{
    [Activity(
        Label = "Example.Droid"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/AppTheme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.splash_screen)
        {
        }
    }
}