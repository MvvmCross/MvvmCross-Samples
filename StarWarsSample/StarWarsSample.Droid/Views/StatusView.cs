using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using OxyPlot.Xamarin.Android;
using StarWarsSample.Core.Resources;
using StarWarsSample.Core.ViewModels;

namespace StarWarsSample.Droid.Views
{
    [MvxFragmentPresentation(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("starWarsSample.droid.views.StatusView")]
    public class StatusView : BaseFragment<StatusViewModel>
    {
        protected override int FragmentId => Resource.Layout.StatusView;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = base.OnCreateView(inflater, container, savedInstanceState);

            ParentActivity.SupportActionBar.Title = Strings.DeathStarStatus;

            var plot = view.FindViewById<PlotView>(Resource.Id.plot_view);
            plot.Model = ViewModel.PlotModel;

            return view;
        }

    }
}
