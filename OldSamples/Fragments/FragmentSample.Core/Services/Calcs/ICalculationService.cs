namespace FragmentSample.Core.Services.Calcs
{
    public interface ICalculationService
    {
        double TipAmount(double subTotal, int generosity);
    }
}