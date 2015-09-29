using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Cirrious.MvvmCross.Droid.Views;

namespace DailyDilbert.Droid.Views
{
    [Activity(Label = "View for ListViewModel")]
    public class ListView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.ListView);
        }
    }
}