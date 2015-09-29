using Cirrious.CrossCore.IoC;
using Cirrious.CrossCore.Plugins;
using Cirrious.MvvmCross.Plugins.Messenger;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.WindowsStore.Platform;
using Windows.UI.Xaml.Controls;

namespace FractalGen.UI.Store
{
    public class Setup : MvxStoreSetup
    {
        public Setup(Frame rootFrame) : base(rootFrame)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new Core.App();
        }

        protected override void InitializeFirstChance()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
            base.InitializeFirstChance();
        }

        public override void LoadPlugins(IMvxPluginManager pluginManager)
        {
            pluginManager.EnsurePluginLoaded<PluginLoader>();
            base.LoadPlugins(pluginManager);
        }
    }
}