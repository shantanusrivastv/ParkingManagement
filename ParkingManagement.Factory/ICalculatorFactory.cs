using ParkingCalculator.Common;

namespace ParkingManagement.Factory
{
    public interface ICalculatorFactory<out T> where T : class, ICalculator
    {
        T CreateCalculator(CalculatorType calculatorType);
    }
}