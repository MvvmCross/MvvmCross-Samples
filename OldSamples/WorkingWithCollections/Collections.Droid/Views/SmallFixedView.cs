using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Small Fixed", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SmallFixedView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_FixedView);
        }
    }
}