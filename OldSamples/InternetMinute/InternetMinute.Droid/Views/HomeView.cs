using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;

namespace InternetMinute.Droid.Views
{
    [Activity(Label = "Internet time is ticking")]
    public class HomeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.HomeView);
        }   
    }
}