using Android.App;
using Android.Content.PM;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.AutoView.Droid.Views;
using Cirrious.MvvmCross.AutoView.Droid.Views.Dialog;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Views;

namespace AutoViewExamples.Droid
{
    [Activity(
		Label = "AutoViewExamples.Droid"
		, MainLauncher = true
		, Icon = "@drawable/icon"
		, Theme = "@style/Theme.Splash"
		, NoHistory = true
		, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {

        }

        protected override void OnCreate(Android.OS.Bundle bundle)
        {
            base.OnCreate(bundle);
        }

        protected override void TriggerFirstNavigate()
        {
            var builder = new AlertDialog.Builder(this);
            builder.SetMessage("What kind of autodialogs would you like?")
                .SetPositiveButton("Linear dialogs", (sender, args) =>
                {
                    MvxAutoDialogViewFinder.DialogViewType = typeof(MvxLinearAutoDialogActivity);
                    var starter = Mvx.Resolve<IMvxAppStart>();
                    starter.Start();
                })
                .SetNegativeButton("Listview dialogs", (sender, args) =>
                {
                    MvxAutoDialogViewFinder.DialogViewType = typeof(MvxAutoDialogActivity);
                    var starter = Mvx.Resolve<IMvxAppStart>();
                    starter.Start();
                });
            RunOnUiThread(() => builder.Show());
        }
    }
}