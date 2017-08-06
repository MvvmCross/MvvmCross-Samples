using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace Soba.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            RegisterNavigationServiceAppStart<ViewModels.FirstViewModel>();
        }
    }
}