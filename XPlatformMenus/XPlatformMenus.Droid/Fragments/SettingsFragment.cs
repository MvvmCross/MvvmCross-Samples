using Android.Runtime;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Shared.Attributes;

namespace XPlatformMenus.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xplatformmenus.droid.fragments.SettingsFragment")]
    public class SettingsFragment : BaseFragment<SettingsViewModel>
    {
		protected override int FragmentId => Resource.Layout.fragment_settings;
    }
}