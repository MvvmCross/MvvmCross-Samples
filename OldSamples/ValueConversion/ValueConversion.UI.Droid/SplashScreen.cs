using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace ValueConversion.UI.Droid
{
    [Activity(Label = "ValueConversion.UI.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.Main)
        {
        }
    }
}