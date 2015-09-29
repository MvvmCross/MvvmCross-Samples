using Cirrious.CrossCore.IoC;
using Cirrious.MvvmCross.ViewModels;
using FractalGen.Core.ViewModels;

namespace FractalGen.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Generator")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Converter")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsSingleton();

            RegisterAppStart<GenerateViewModel>();
        }
    }
}