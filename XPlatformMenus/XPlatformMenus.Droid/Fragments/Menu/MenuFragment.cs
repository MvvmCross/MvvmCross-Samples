using System;
using System.Threading.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Views;
using XPlatformMenus.Core.ViewModels;
using XPlatformMenus.Droid.Activities;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using MvvmCross.Binding.Droid.BindingContext;

namespace XPlatformMenus.Droid.Fragments
{
	[MvxFragment(typeof(MainViewModel), Resource.Id.navigation_frame)]
    [Register("xplatformmenus.droid.fragments.MenuFragment")]
    public class MenuFragment : MvxFragment<MenuViewModel>, NavigationView.IOnNavigationItemSelectedListener
    {
        private NavigationView _navigationView;
        private IMenuItem _previousMenuItem;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(Resource.Layout.fragment_navigation, null);

            _navigationView = view.FindViewById<NavigationView>(Resource.Id.navigation_view);
            _navigationView.SetNavigationItemSelectedListener(this);
            _navigationView.Menu.FindItem(Resource.Id.nav_home).SetChecked(true);

            return view;
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            if (item != _previousMenuItem)
            {
                _previousMenuItem?.SetChecked(false);
            }
            
            item.SetCheckable(true);
            item.SetChecked(true);

            _previousMenuItem = item;

            Navigate (item.ItemId);

            return true;
        }

        private async Task Navigate(int itemId)
        {
            ((MainActivity)Activity).DrawerLayout.CloseDrawers ();

            // add a small delay to prevent any UI issues
            await Task.Delay (TimeSpan.FromMilliseconds (250));

            switch (itemId) 
            {
                case Resource.Id.nav_home:
                    ViewModel.ShowHomeCommand.Execute();
                    break;
                case Resource.Id.nav_viewpager:
                    ViewModel.ShowViewPagerCommand.Execute();
                    break;
                case Resource.Id.nav_recyclerview:
                    ViewModel.ShowRecyclerCommand.Execute();
                    break;
                case Resource.Id.nav_settings:
                    ViewModel.ShowSettingCommand.Execute();
                    break;
                case Resource.Id.nav_helpfeedback:
                    ViewModel.ShowHelpCommand.Execute();
                    break;
            }
        }
    }
}
