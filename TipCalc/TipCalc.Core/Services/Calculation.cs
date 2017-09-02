namespace TipCalc.Core.Services
{
    public class Calculation : ICalculation
    {
        public double TipAmount(double subTotal, int generosity)
        {
            return subTotal * generosity / 100.0;
        }
    }
}
