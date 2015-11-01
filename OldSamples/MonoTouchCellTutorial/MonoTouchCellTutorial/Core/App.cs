using Cirrious.CrossCore;
using Cirrious.MvvmCross.ViewModels;
using MonoTouchCellTutorial.Core.Interfaces;
using MonoTouchCellTutorial.Core.Services;

namespace MonoTouchCellTutorial.Core
{
    public class App
        : MvxApplication
    {
        public App()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            Mvx.RegisterSingleton<IPricingModel>(new PricingModel());
            Mvx.RegisterSingleton<IAnimalSupplier>(new AnimalSupplier());
        }
    }
}