using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace PictureTaking.Droid.Droid
{
    [Activity(Label = "Your App Name", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}