using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.DownloadCache;
using Cirrious.MvvmCross.ViewModels;
using Collections.Core;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;

namespace Collections.Touch
{
    public class Setup
        : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            var app = new App();
            return app;
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.DownloadCache.Touch.Plugin>();
            registry.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.File.Touch.Plugin>();
            base.AddPluginsLoaders(registry);
        }

        protected override void InitializeLastChance()
        {
            PluginLoader.Instance.EnsureLoaded();
            Cirrious.MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            Cirrious.MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();

            base.InitializeLastChance();
        }
    }
}