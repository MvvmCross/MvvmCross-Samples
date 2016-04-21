using Android.Runtime;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;
using Android.Views;
using Android.OS;

namespace XPlatformMenus.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xplatformmenus.droid.fragments.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
		protected override int FragmentId => Resource.Layout.fragment_home;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.showHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }
    }
}