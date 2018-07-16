using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.Core
{
    public class TwitterSearchApp
        : MvxApplication
    {
        public TwitterSearchApp()
        {
            InitaliseServices();
            InitialiseStartNavigation();
            InitialisePlugIns();
        }

        private void InitaliseServices()
        {
            CreatableTypes()
                .EndingWith("SearchProvider")
                .AsInterfaces()
                .RegisterAsSingleton();
        }

        private void InitialiseStartNavigation()
        {
            RegisterAppStart<HomeViewModel>();
        }

        private void InitialisePlugIns()
        {
            //https://github.com/MvvmCross/MvvmCross/issues/2082
            //https://github.com/MvvmCross/MvvmCross/pull/2603
            //MvvmCross.Plugin.Visibility.PluginLoader.Instance.EnsureLoaded();
        }
    }
}