using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Plugins;

namespace BestSellers.Touch
{
    public class Setup
        : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxIosViewPresenter presenter)
            : base(applicationDelegate, presenter)
        {
        }


        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry registry)
        {
            registry.Register<MvvmCross.Plugins.Visibility.PluginLoader, MvvmCross.Plugins.Visibility.iOS.Plugin>();
            registry.Register<MvvmCross.Plugins.DownloadCache.PluginLoader , MvvmCross.Plugins.DownloadCache.iOS.Plugin>();
            registry.Register<MvvmCross.Plugins.File.PluginLoader , MvvmCross.Plugins.File.iOS.Plugin>();
			//registry.Register<MvvmCross.Plugins.Json.PluginLoader, MvvmCross.Plugins.Json.iOS.Plugin>();

			base.AddPluginsLoaders(registry);
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Visibility.PluginLoader>();
            //pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Json.PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.DownloadCache.PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.File.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }


        protected override IMvxApplication CreateApp()
        {
            var app = new BestSellers.App();
            return app;
        }

        protected override void InitializeLastChance()
        {
            // create a new error displayer - it will hook itself into the framework
            var errorDisplayer = new ErrorDisplayer();

            base.InitializeLastChance();
        }
    }
}