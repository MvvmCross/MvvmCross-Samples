using Cirrious.CrossCore.IoC;
using InternetMinute.Core.ViewModels;

namespace InternetMinute.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsSingleton();
				
            RegisterAppStart<HomeViewModel>();
        }
    }
}