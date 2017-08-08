using Android.App;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;

namespace BestSellers.Droid
{
    [Activity(Label = "Bestseller", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity 
        : MvxSplashScreenActivity
    {
        public SplashScreenActivity()
            : base(Resource.Layout.SplashScreen)
        {
        }
    }
}

