using Cirrious.CrossCore;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.ViewModels;
using CustomerManagement.Core.Interfaces;

namespace CustomerManagement.Touch
{
    public class Setup
        : MvxTouchDialogSetup
    {
        private CustomerManagementPresenter _presenter;

        public Setup(MvxApplicationDelegate applicationDelegate, CustomerManagementPresenter presenter)
            : base(applicationDelegate, presenter)
        {
            _presenter = presenter;
        }

        protected override IMvxApplication CreateApp()
        {
            var app = new App();
            return app;
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.PhoneCall.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.WebBrowser.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.File.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.ResourceLoader.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>();
            base.AddPluginsLoaders(registry);
        }

        protected override void InitializeLastChance()
        {
            base.InitializeLastChance();

            Mvx.RegisterSingleton<IViewModelCloser>(_presenter);
            Cirrious.MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            Cirrious.MvvmCross.Plugins.DownloadCache.PluginLoader.Instance.EnsureLoaded();
        }
    }
}