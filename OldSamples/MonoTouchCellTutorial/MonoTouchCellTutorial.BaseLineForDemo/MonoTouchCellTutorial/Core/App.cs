using Cirrious.CrossCore;
using MonoTouchCellTutorial.Core.Interfaces;
using MonoTouchCellTutorial.Core.Services;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore.IoC;

namespace MonoTouchCellTutorial.Core
{
	public class App 
		: MvxApplication
	{
		public App ()
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

