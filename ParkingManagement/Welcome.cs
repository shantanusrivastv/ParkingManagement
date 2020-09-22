using System;
using ParkingCalculator;
using ParkingCalculator.Common;
using ParkingManagement.Factory;

namespace ParkingManagement.Core
{
    public class Welcome : IWelcome
    {
        public decimal EnterParking(string userInputCalculatorType)
        {
            if (Enum.IsDefined(typeof(CalculatorType), userInputCalculatorType))
            {
                var calculatorType = Enum.Parse<CalculatorType>(userInputCalculatorType);
                // Preferred way DI
                var factory = new CalculatorFactory<IParkingCalculator>();

                var selectedCalculator = factory.CreateCalculator(calculatorType);

                return new ParkingManager(selectedCalculator).GetTotalParkingFee();
            }
            else
            {
                throw new InvalidOperationException("Wrong Calculator Passed");
            }
        }
    }
}