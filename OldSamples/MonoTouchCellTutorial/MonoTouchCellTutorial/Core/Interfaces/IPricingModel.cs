using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace MonoTouchCellTutorial.Core.Interfaces
{    
	public interface IPricingModel
	{
		int CalculateInitialSalesPrice(int purchaseCost);
	}
}