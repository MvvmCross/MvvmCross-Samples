using Android.App;
using Android.OS;
using DailyDilbert.Droid;
using MvvmCross.Droid.Views;

namespace DailyGarfield.Droid.Views
{
    [Activity(Label = "View for DetailViewModel")]
    public class DetailView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.DetailView);
        }
    }
}