using System.Collections.Generic;
using System.Reflection;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.Color;
using Cirrious.MvvmCross.ViewModels;
using ValueConversion.Core;
using Cirrious.MvvmCross.Touch.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.Plugins.Visibility;

namespace ValueConversion.UI.Touch
{
    public class Setup : MvxTouchSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
			: base(applicationDelegate, presenter)
        {
        }

        protected override List<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies;
                toReturn.Add(typeof (MvxNativeColorValueConverter).Assembly);
                toReturn.Add(typeof (MvxVisibilityValueConverter).Assembly);
                return toReturn;
            }
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override void AddPluginsLoaders(MvxLoaderPluginRegistry loaders)
        {
            base.AddPluginsLoaders(loaders);
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Color.Touch.Plugin>();
            loaders.AddConventionalPlugin<Cirrious.MvvmCross.Plugins.Visibility.Touch.Plugin>();
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
			pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.Color.PluginLoader>();
            pluginManager.EnsurePluginLoaded<Cirrious.MvvmCross.Plugins.Visibility.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
}