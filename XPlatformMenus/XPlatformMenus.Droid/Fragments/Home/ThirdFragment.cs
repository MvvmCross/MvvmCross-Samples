using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Droid.Support.V7.AppCompat;
using XPlatformMenus.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using XPlatformMenus.Droid.Activities;

namespace XPlatformMenus.Droid.Fragments
{
    [MvxFragment(typeof(MainViewModel), Resource.Id.content_frame, true)]
    [Register("xplatformmenus.droid.fragments.ThirdFragment")]
    public class ThirdFragment : BaseFragment<ThirdViewModel>
    {
        string oldTitle;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            oldTitle = ((MainActivity)Activity).Title;
            ((MainActivity)Activity).Title = "Third Fragment";

            return base.OnCreateView(inflater, container, savedInstanceState);        
        }

        public override void OnDestroyView()
        {
            ((MainActivity)Activity).Title = oldTitle;
            base.OnDestroyView();
        }

        protected override int FragmentId 
        {
            get 
            {
                return Resource.Layout.fragment_third;
            }
        }
    }
}