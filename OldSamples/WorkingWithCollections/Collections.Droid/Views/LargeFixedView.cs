using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Large Fixed", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LargeFixedView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_FixedView);
        }
    }
}