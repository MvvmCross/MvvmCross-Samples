using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;
using MonoTouchCellTutorial.Core.Models.Dogs;
using MonoTouchCellTutorial.Core.Models.Kittens;

namespace MonoTouchCellTutorial.Core.Interfaces
{
	public interface IAnimalSupplier
	{
		 int KittenPrice { get; }
		 int DogPrice { get; }
		 Kitten BuyKitten();
		 Dog BuyDog();
	}
}