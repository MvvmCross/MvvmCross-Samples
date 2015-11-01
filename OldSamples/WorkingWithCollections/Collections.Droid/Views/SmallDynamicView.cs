using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Small Dynamic", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SmallDynamicView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_DynamicView);
        }
    }
}