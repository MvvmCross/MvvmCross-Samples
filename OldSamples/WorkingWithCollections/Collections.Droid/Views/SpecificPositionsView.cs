using Android.App;
using Android.Content.PM;
using Cirrious.MvvmCross.Droid.Views;

namespace Collections.Droid.Views
{
    [Activity(Label = "Specific Positions", ScreenOrientation = ScreenOrientation.Portrait)]
    public class SpecificPositionsView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_SpecificPositions);
        }
    }
}