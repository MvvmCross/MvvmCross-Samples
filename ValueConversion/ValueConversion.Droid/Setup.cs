using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using ValueConversion.Core;
using PluginLoader = MvvmCross.Plugins.Color.PluginLoader;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.Color;
using MvvmCross.Plugins.Visibility;
using MvvmCross.Dialog.Droid;
using System.Collections;

namespace ValueConversion.UI.Droid
{
    public class Setup
        : MvxAndroidDialogSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

		protected override IEnumerable<Assembly> ValueConverterAssemblies {
			get {
				var toReturn = base.ValueConverterAssemblies as IList;
				toReturn.Add(typeof (MvxNativeColorValueConverter).Assembly);
				toReturn.Add(typeof (MvxVisibilityValueConverter).Assembly);
				return (IEnumerable<Assembly>)toReturn;
			}
		}

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Visibility.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }
}