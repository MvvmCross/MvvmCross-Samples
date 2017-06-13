using System;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7.RecyclerView;
using StarWarsSample.Droid.Extensions;
using StarWarsSample.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("starWarsSample.droid.views.PeopleView")]
    public class PeopleView : BaseFragment<PeopleViewModel>
    {
        protected override int FragmentId => Resource.Layout.PeopleView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = "Target: People";

            var recyclerView = view.FindViewById<MvxRecyclerView>(Resource.Id.people_recycler_view);
            if (recyclerView != null)
            {
                recyclerView.HasFixedSize = true;
                var layoutManager = new LinearLayoutManager(Activity);
                recyclerView.SetLayoutManager(layoutManager);

                recyclerView.AddOnScrollFetchItemsListener(layoutManager, () => ViewModel.FetchPeopleTask, () => this.ViewModel.FetchPeopleCommand);
            }

            return view;
        }

    }
}
