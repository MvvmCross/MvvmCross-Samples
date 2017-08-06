using DailyGarfield.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace DailyGarfield.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ListViewModel>();
        }
    }
}