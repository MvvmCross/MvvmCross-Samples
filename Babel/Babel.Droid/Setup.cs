using MvvmCross.Platforms.Android.Core;
using MvvmCross.Plugin;

namespace Babel.Droid
{
    public class Setup : MvxAndroidSetup<Core.App>
    {
        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            base.LoadPlugins(pluginManager);

            pluginManager.EnsurePluginLoaded<MvvmCross.Plugin.Json.Plugin>();
        }
    }
}
