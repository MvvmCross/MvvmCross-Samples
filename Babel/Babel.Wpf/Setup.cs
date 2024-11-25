using MvvmCross;
using MvvmCross.Base;
using MvvmCross.Platforms.Wpf.Core;
using MvvmCross.Plugin;
using MvvmCross.Plugin.ResourceLoader.Platforms.Wpf;

namespace Babel.Wpf
{
    public class Setup : MvxWpfSetup<Core.App>
    {
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);

            Mvx.IoCProvider.RegisterType<IMvxResourceLoader, MvxWpfResourceLoader>();

            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Json.Plugin>();
        }
    }
}
