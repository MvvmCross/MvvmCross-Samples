using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.IoC;

namespace PictureTaking.Touch
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}