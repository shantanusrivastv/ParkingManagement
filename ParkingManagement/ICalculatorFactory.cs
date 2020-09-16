using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement
{
    public interface ICalculatorFactory<T> where T : class, IParkingCalculator
    {
        T CreateCalculator(CalculatorType commandType);
    }
}