using MvvmCross.Platform.IoC;
using FirstDemo.Core.ViewModels;

namespace FirstDemo.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<FirstViewModel>();
        }
    }
}