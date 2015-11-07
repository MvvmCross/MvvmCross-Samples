using Android.Runtime;
using Cirrious.MvvmCross.Droid.Support.Fragging;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Droid.Fragments
{
    [MvxOwnedViewModelFragment]
    [Register("xplatformmenus.droid.fragments.HomeFragment")]
    public class HomeFragment : BaseFragment<HomeViewModel>
    {
        protected override int FragmentId 
        {
            get 
            {
                return Resource.Layout.fragment_home;
            }
        }
    }
}