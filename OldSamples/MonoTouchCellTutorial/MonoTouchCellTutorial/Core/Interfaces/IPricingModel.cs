namespace MonoTouchCellTutorial.Core.Interfaces
{
    public interface IPricingModel
    {
        int CalculateInitialSalesPrice(int purchaseCost);
    }
}