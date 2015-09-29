using MonoTouchCellTutorial.Core.Interfaces;

namespace MonoTouchCellTutorial.Core.Services
{
	public class PricingModel : IPricingModel
	{
		public int CalculateInitialSalesPrice (int purchaseCost)
		{
			var toReturn = purchaseCost * 2;
			// TODO - a real sales model would have a lot of different business rules here..
			return toReturn;
		}
	}
}