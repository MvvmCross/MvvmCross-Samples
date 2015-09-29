using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using FragmentSample.Core.ViewModels;

namespace FragmentSample.Core
{
    public class App
        : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            InitialisePlugins();
            InitaliseServices();
            InitialiseStartNavigation();
        }

        private void InitaliseServices()
        {
            CreatableTypes().EndingWith("Service").AsInterfaces().RegisterAsLazySingleton();
        }

        private void InitialiseStartNavigation()
        {
            RegisterAppStart<HomeViewModel>();
        }

        private void InitialisePlugins()
        {
            // initialise any plugins where are required at app startup
            // e.g. Cirrious.MvvmCross.Plugins.Visibility.PluginLoader.Instance.EnsureLoaded();
        }
    }
}