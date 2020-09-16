using ParkingManagement.Common;

namespace ParkingCalculator.Factory
{
    public interface ICalculatorFactory<out T> where T : class, IParkingCalculator
    {
        T CreateCalculator(CalculatorType calculatorType);
    }
}