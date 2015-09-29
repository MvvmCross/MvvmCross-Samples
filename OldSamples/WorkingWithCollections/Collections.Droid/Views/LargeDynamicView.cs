using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Large Dynamic", ScreenOrientation = ScreenOrientation.Portrait)]
    public class LargeDynamicView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_DynamicView);
        }
    }
}