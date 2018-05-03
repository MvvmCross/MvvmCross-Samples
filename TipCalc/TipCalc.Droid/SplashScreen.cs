using Android;
using Android.App;
using Android.Content.PM;
using MvvmCross.Platforms.Android.Views;

namespace TipCalc.UI.Droid
{
    [Activity(
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@style/Theme.Splash",
        NoHistory = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}