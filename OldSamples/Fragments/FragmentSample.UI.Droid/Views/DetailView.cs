using Android.App;
using Android.Views;
using Android.Widget;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.ViewModels;
using FragmentSample.Core.ViewModels.Shakespeare;

namespace FragmentSample.UI.Droid.Views
{
    [Activity]
    public class DetailView
        : MvxFragmentActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_DetailView);
            SetDetailFragmentDataContext();
        }

        private void SetDetailFragmentDataContext()
        {
            var fragment = (DetailFragment)SupportFragmentManager.FindFragmentById(Resource.Id.detail_fragment);
            fragment.ViewModel = ViewModel;
        }
    }
}