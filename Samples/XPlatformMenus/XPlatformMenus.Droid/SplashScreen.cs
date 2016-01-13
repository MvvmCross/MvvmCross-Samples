using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace XPlatformMenus.Droid
{
    [Activity(
		Label = "XPlatformMenus.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/AppTheme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen() : base(Resource.Layout.splash_screen)
        {
        }
    }
}