using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement
{
    public interface ICalculatorFactory<out T> where T : class, IParkingCalculator
    {
        T CreateCalculator(CalculatorType calculatorType);
    }
}