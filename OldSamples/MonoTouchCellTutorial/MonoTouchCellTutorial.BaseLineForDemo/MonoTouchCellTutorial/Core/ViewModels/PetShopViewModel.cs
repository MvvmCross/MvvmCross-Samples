using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MonoTouchCellTutorial.Core.Models.Dogs;
using MonoTouchCellTutorial.Core.Models.Kittens;
using MonoTouchCellTutorial.Core.Models;
using MonoTouchCellTutorial.Core.Interfaces;

namespace MonoTouchCellTutorial.Core.ViewModels
{
	public class PetShopViewModel : MvxViewModel
    {
		private ObservableCollection<PetShopAnimalViewModel> _stock;
		public ObservableCollection<PetShopAnimalViewModel> Stock
        {
            get { return _stock; }
            set { _stock = value; RaisePropertyChanged(() => Stock); }
        }

        public ICommand AddKittenCommand
        {
            get
            {
                return new MvxCommand(DoAddKitten);
            }
        }

		public ICommand AddDogCommand
		{
			get
			{
				return new MvxCommand(DoAddDog);
			}
		}

		private int _sales;
		public int Sales {
			get { return _sales; }
			set { _sales = value; RaisePropertyChanged (() => Sales); }
		}

		private int _revenue;
		public int Revenue {
			get { return _revenue; }
			set { _revenue = value; RaisePropertyChanged (() => Revenue); }
		}
		
		private int _bankBalance;
		public int BankBalance {
			get { return _bankBalance; }
			set { _bankBalance = value; RaisePropertyChanged (() => BankBalance); }
		}

		private readonly IAnimalSupplier _animalSupplier;
		private readonly IPricingModel _pricingModel;

		public PetShopViewModel(IAnimalSupplier animalSupplier, IPricingModel pricingModel)
		{
			_animalSupplier = animalSupplier;
			_pricingModel = pricingModel;

			Stock = new ObservableCollection<PetShopAnimalViewModel>();
		}
		
		private void DoAddKitten()
        {
            var kitten = _animalSupplier.BuyKitten();
			var cost = _animalSupplier.KittenPrice;
			DoBuyAnimal(kitten, cost);
		}

		private void DoAddDog()
		{
			var dog = _animalSupplier.BuyDog();
			var cost = _animalSupplier.DogPrice;
			DoBuyAnimal(dog, cost);
		}

		private void DoBuyAnimal (Animal animal, int cost)
		{
			var newStock = new PetShopAnimalViewModel();
			newStock.Animal = animal;
			newStock.Price = _pricingModel.CalculateInitialSalesPrice(cost);
			newStock.SellCommand = new MvxCommand(() => DoSale(newStock));

			BankBalance = BankBalance - cost;
			Stock.Add(newStock);
		}

		private void DoSale (PetShopAnimalViewModel toSell)
		{
			Stock.Remove(toSell);
			Sales = Sales + 1;
			Revenue = Revenue + toSell.Price;
			BankBalance = BankBalance + toSell.Price;
		}
    }
}