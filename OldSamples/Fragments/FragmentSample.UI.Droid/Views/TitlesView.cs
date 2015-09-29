using Android.App;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.ViewModels;
using FragmentSample.Core.ViewModels.Shakespeare;

namespace FragmentSample.UI.Droid.Views
{
    [Activity]
    public class TitlesView
        : MvxFragmentActivity
        , IFragmentHost
    {
        private DetailFragment _detailFragment;

        public TitlesViewModel TitlesViewModel
        {
            get { return (TitlesViewModel)base.ViewModel; }
        }

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_TitlesView);
            SetTitlesFragmentDataContext();
            DetectDetailFragmentDataContext();
            if (_detailFragment != null)
                RegisterForDetailRequests();
        }

        private void RegisterForDetailRequests()
        {
            var customPresenter = Mvx.Resolve<ICustomPresenter>();
            customPresenter.Register(typeof(DetailViewModel), this);
        }

        private void DetectDetailFragmentDataContext()
        {
            _detailFragment = (DetailFragment)SupportFragmentManager.FindFragmentById(Resource.Id.detail_fragment); ;
        }

        private void SetTitlesFragmentDataContext()
        {
            var listFragment = (TitlesFragment)SupportFragmentManager.FindFragmentById(Resource.Id.titles_fragment);
            listFragment.ViewModel = ViewModel;
        }

        public bool Show(MvxViewModelRequest request)
        {
            if (_detailFragment == null)
                return false;

            if (!_detailFragment.IsVisible)
                return false;

            if (request.ViewModelType != typeof(DetailViewModel))
                return false;

            // TODO - replace this with extension method when available
            var loaderService = Mvx.Resolve<IMvxViewModelLoader>();
            var viewModel = loaderService.LoadViewModel(request, null /* saved state */);
            _detailFragment.ViewModel = viewModel;

            return true;
        }
    }
}