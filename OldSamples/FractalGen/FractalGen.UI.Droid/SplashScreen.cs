using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace FractalGen.UI.Droid
{
    [Activity(Label = "FractalGen.UI.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.Main)
        {
        }
    }
}