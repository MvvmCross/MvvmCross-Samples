using Windows.UI.Xaml.Controls;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Plugins;
using MvvmCross.Plugins.Color;
using MvvmCross.WindowsCommon.Platform;

namespace ValueConversion.UI.WindowsStore
{
    public class Setup : MvxWindowsSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<PluginLoader>();
            pluginManager.EnsurePluginLoaded<MvvmCross.Plugins.Visibility.PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }
}