using Android.App;
using Android.OS;
using Cirrious.MvvmCross.Droid.Fragging;
using FragmentSample.Core.ViewModels.Tab;

namespace FragmentSample.UI.Droid.Views
{
    [Activity]
    public class TabView : MvxTabsFragmentActivity
    {
        public TabViewModel TabViewModel
        {
            get { return (TabViewModel)base.ViewModel; }
        }

        public TabView()
            : base(Resource.Layout.Page_TabView, Resource.Id.actualtabcontent)
        {
        }

        protected override void AddTabs(Bundle args)
        {
            AddTab<Tab1Fragment>("Tab1", "Tab 1", args, TabViewModel.Vm1);
            AddTab<Tab2Fragment>("Tab2", "Tab 2", args, TabViewModel.Vm2);
            // note that
            AddTab<Tab3Fragment>("Tab3.1", "Tab 3.1", args, TabViewModel.Vm3);
            AddTab<Tab3Fragment>("Tab3.2", "Tab 3.2", args, TabViewModel.Vm3);
            AddTab<Tab3BigFragment>("Tab3.3", "Tab 3.3", args, TabViewModel.Vm3);
        }
    }
}