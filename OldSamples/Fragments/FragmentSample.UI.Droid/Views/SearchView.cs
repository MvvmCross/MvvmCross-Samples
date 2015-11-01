using Android.App;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using FragmentSample.Core.ViewModels.Form;

namespace FragmentSample.UI.Droid.Views
{
    [Activity]
    public class SearchView
        : MvxFragmentActivity
    {
        public SearchViewModel SearchViewModel
        {
            get { return (SearchViewModel)base.ViewModel; }
        }

        private MyFirstFragment _firstFragment;
        private MySecondFragment _secondFragment;
        private bool _showingFirst;

        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.Page_FormView);

            SetListFragmentDataContext();

            _firstFragment = new MyFirstFragment()
                {
                    ViewModel = ViewModel
                };
            _secondFragment = new MySecondFragment()
                {
                    ViewModel = ViewModel
                };

            _showingFirst = true;
            ShowFormHeaderFragment(_firstFragment);

            var b = FindViewById<Button>(Resource.Id.switchFragmentButton);
            b.Click += (s, e) => SwitchHeaders();
        }

        private void SwitchHeaders()
        {
            if (_showingFirst)
                ShowFormHeaderFragment(_secondFragment);
            else
                ShowFormHeaderFragment(_firstFragment);
            _showingFirst = !_showingFirst;
        }

        private void SetListFragmentDataContext()
        {
            var listFragment = (MyListFragment) SupportFragmentManager.FindFragmentById(Resource.Id.list_fragment);
            listFragment.ViewModel = ViewModel;
        }

        private void ShowFormHeaderFragment(MvxFragment myFragment)
        {
            var t = SupportFragmentManager.BeginTransaction();
            t.Replace(Resource.Id.titles_fragment_holder, myFragment);
            t.Commit();
        }
    }
}