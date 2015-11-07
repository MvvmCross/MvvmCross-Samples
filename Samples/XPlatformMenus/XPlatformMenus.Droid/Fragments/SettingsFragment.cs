using Android.Runtime;
using Cirrious.MvvmCross.Droid.Support.Fragging;
using XPlatformMenus.Core.ViewModels;

namespace XPlatformMenus.Droid.Fragments
{
    [MvxOwnedViewModelFragment]
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