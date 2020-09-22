using ParkingCalculator;
using ParkingManagement.Common;

namespace ParkingManagement.Factory
{
    public interface ICalculatorFactory<out T> where T : class, IParkingCalculator
    {
        T CreateCalculator(CalculatorType calculatorType);
    }
}