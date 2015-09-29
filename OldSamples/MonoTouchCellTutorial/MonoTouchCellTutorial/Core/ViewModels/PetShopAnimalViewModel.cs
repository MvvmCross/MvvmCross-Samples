using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using MonoTouchCellTutorial.Core.Models;

namespace MonoTouchCellTutorial.Core.ViewModels
{
	public class PetShopAnimalViewModel : MvxViewModel
	{
		Animal _animal;
		public Animal Animal {
			get { return _animal; }
			set { _animal = value; RaisePropertyChanged(() => Animal); }
		}

		private int _price;
		public int Price {
			get { return _price; }
			set { _price = value; RaisePropertyChanged(() => Price); }
		}

		public ICommand IncreasePrice {
			get { return new MvxCommand (() => Price = Price + 1); }
		}

		public ICommand DecreasePrice {
			get { return new MvxCommand (() => Price = Price - 1); }
		}

		public ICommand SellCommand { get; set; }
	}
}