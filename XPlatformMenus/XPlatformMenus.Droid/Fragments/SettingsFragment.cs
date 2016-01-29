using Android.Runtime;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;

namespace XPlatformMenus.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame)]
    [Register("xplatformmenus.droid.fragments.SettingsFragment")]
    public class SettingsFragment : BaseFragment<SettingsViewModel>
    {
        protected override int FragmentId
        {
            get
            {
                return Resource.Layout.fragment_settings;
            }
        }
    }
}