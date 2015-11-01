using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace ValueConversion.UI.Droid.Views
{
    [Activity]
    public class TwoWayView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_TwoWay);
        }
    }
}