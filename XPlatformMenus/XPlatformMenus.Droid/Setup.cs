using Android.Content;
using System.Collections.Generic;
using System.Reflection;
using XPlatformMenus.Core.Interfaces;
using XPlatformMenus.Droid.Services;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V7.Fragging.Presenter;
using MvvmCross.Platform;

namespace XPlatformMenus.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext)
            : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

		protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
		{
			typeof(Android.Support.Design.Widget.NavigationView).Assembly,
			typeof(Android.Support.Design.Widget.FloatingActionButton).Assembly,
			typeof(Android.Support.V7.Widget.Toolbar).Assembly,
			typeof(Android.Support.V4.Widget.DrawerLayout).Assembly,
			typeof(Android.Support.V4.View.ViewPager).Assembly,
			typeof(MvvmCross.Droid.Support.V7.RecyclerView.MvxRecyclerView).Assembly
		};

		/// <summary>
		/// This is very important to override. The default view presenter does not know how to show fragments!
		/// </summary>
		protected override IMvxAndroidViewPresenter CreateViewPresenter()
		{
			var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
			Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
			return mvxFragmentsPresenter;
		}

        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();

            Mvx.RegisterSingleton<IDialogService>(() => new DialogService());
        }
    }
}