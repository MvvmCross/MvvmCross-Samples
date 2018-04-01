using ApiExamples.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace ApiExamples.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<FirstViewModel>();
        }
    }
}