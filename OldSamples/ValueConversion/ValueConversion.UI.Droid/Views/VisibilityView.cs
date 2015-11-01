using Android.App;
using Cirrious.MvvmCross.Droid.Views;

namespace ValueConversion.UI.Droid.Views
{
    [Activity]
    public class VisibilityView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.View_Visibility);
        }
    }
}