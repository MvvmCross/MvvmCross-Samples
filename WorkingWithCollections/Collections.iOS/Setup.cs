using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.DownloadCache;
using MvvmCross.Platform.Plugins;


namespace Collections.Touch
{
    public class Setup
        : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
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
			registry.AddConventionalPlugin<MvvmCross.Plugins.DownloadCache.iOS.Plugin>();
			registry.AddConventionalPlugin<MvvmCross.Plugins.File.iOS.Plugin>();
            base.AddPluginsLoaders(registry);
        }

        protected override void InitializeLastChance()
        {
            PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.File.PluginLoader.Instance.EnsureLoaded();
            MvvmCross.Plugins.Json.PluginLoader.Instance.EnsureLoaded();

            base.InitializeLastChance();
        }
    }
}