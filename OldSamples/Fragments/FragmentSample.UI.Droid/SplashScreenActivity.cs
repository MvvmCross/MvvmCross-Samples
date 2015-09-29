using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace FragmentSample.UI.Droid
{
    [Activity(Label = "FragmentSample", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity
        : MvxSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}

