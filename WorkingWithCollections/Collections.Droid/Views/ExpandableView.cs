using Android.App;
using Android.Content.PM;
using MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Expandable", ScreenOrientation = ScreenOrientation.Portrait)]
    public class ExpandableView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_ExpandableView);
        }
    }
}