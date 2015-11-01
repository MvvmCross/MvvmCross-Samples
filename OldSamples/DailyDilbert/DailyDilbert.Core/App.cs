using Cirrious.CrossCore.IoC;
using DailyDilbert.Core.ViewModels;

namespace DailyDilbert.Core
{
    public class App : Cirrious.MvvmCross.ViewModels.MvxApplication
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