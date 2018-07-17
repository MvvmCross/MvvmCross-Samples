using Android.App;
using MvvmCross.Platforms.Android.Views;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.UI.Droid.Views
{
    [Activity(Label = "TwitterSearch")]
    public class TwitterView : MvxActivity<TwitterViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_Twitter);
        }
    }
}