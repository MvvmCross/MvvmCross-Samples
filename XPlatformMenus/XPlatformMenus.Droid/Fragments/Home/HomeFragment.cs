using Android.Runtime;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;

namespace XPlatformMenus.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xplatformmenus.droid.fragments.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
		protected override int FragmentId => Resource.Layout.fragment_home;
    }
}