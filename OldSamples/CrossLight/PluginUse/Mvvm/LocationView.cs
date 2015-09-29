using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Mvvm.Framework;

namespace Mvvm
{
    [Activity(Label = "PluginUse - Mvvm", MainLauncher = true, Icon = "@drawable/icon")]
    public class LocationView : Activity
    {
        private MvxAndroidBindingContext _bindingContext;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // setup the application
            Setup.Instance.EnsureInitialized(ApplicationContext);
            Mvx.Resolve<ITopActivity>().Activity = this;

            // ensure location plugin is available
            Cirrious.MvvmCross.Plugins.Location.PluginLoader.Instance.EnsureLoaded();

            // create the view model
            var viewModel = Mvx.IocConstruct<LocationViewModel>();

            // create the databound UI
            _bindingContext = new MvxAndroidBindingContext(this, new LayoutInflaterProvider(LayoutInflater), viewModel);            
            var view = _bindingContext.BindingInflate(Resource.Layout.Main, null);
            SetContentView(view);
        }

        protected override void OnDestroy()
        {
            _bindingContext.ClearAllBindings();
            base.OnDestroy();
        }
    }
}

