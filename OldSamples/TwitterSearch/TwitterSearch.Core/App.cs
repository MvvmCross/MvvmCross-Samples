using MvvmCross.IoC;
using MvvmCross.ViewModels;
using TwitterSearch.Core.ViewModels;

namespace TwitterSearch.Core
{
    public class App
        : MvxApplication
    {
        public override void Initialize()
        {
            InitaliseServices();
            InitialiseStartNavigation();
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
    }
}