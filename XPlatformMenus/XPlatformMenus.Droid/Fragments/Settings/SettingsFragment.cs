using Android.Runtime;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using Android.Views;
using Android.OS;

namespace XPlatformMenus.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xplatformmenus.droid.fragments.SettingsFragment")]
    public class SettingsFragment : BaseFragment<SettingsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.showHamburgerMenu = true;
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        protected override int FragmentId
        {
            get
            {
                return Resource.Layout.fragment_settings;
            }
        }
    }
}