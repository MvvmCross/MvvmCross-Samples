using MvvmCross.Platform.IoC;

namespace Babel.Ios
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<Core.ViewModels.FirstViewModel>();
        }
    }
}
