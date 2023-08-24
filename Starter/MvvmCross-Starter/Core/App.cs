using Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace Core;

public class App : MvxApplication
{
    public App()
    {
        CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();
        
        // This only works on Android if you are using MvxSetupActivity
        //RegisterAppStart<MainViewModel>();
    }
}