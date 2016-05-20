using Android.Content.Res;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using XPlatformMenus.Droid.Activities;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace XPlatformMenus.Droid.Fragments
{
    public abstract class BaseFragment : MvxFragment
    {
        protected Toolbar _toolbar;
        protected MvxActionBarDrawerToggle _drawerToggle;
        /// <summary>
        /// If true show the hamburger menu
        /// </summary>
        protected bool showHamburgerMenu = false;

        protected BaseFragment()
        {
            RetainInstance = true;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignore = base.OnCreateView(inflater, container, savedInstanceState);

            var view = this.BindingInflate(FragmentId, null);

            _toolbar = view.FindViewById<Toolbar>(Resource.Id.toolbar);
            if (_toolbar != null)
            {
                ((MainActivity)Activity).SetSupportActionBar(_toolbar);
                if (showHamburgerMenu)
                {
                    ((MainActivity)Activity).SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                    _drawerToggle = new MvxActionBarDrawerToggle(
                        Activity,                               // host Activity
                        ((MainActivity)Activity).DrawerLayout,  // DrawerLayout object
                        _toolbar,                               // nav drawer icon to replace 'Up' caret
                        Resource.String.drawer_open,            // "open drawer" description
                        Resource.String.drawer_close            // "close drawer" description
                    );
                    _drawerToggle.DrawerOpened += (object sender, ActionBarDrawerEventArgs e) => ((MainActivity)Activity).HideSoftKeyboard();
                    ((MainActivity)Activity).DrawerLayout.AddDrawerListener(_drawerToggle);
                }
            }
            return view;
        }

        protected abstract int FragmentId { get; }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);
            if (_toolbar != null && null !=_drawerToggle)
            {
                _drawerToggle.OnConfigurationChanged(newConfig);
            }
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            base.OnActivityCreated(savedInstanceState);
            if (_toolbar != null && null != _drawerToggle)
            {
                _drawerToggle.SyncState();
            }
        }
    }

    public abstract class BaseFragment<TViewModel> : BaseFragment where TViewModel : class, IMvxViewModel
    {
        public new TViewModel ViewModel
        {
            get { return (TViewModel)base.ViewModel; }
            set { base.ViewModel = value; }
        }
    }
}

