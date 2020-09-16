using System;

namespace ParkingManagement.ParkingCalculators.Common
{
    public class NotFoundCalculator : IParkingCalculator
    {
        public CalculatorType CalculatorType => CalculatorType.NOTDEFINED;

        public decimal CalculateParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            throw new NotImplementedException("Requested Calculator not found ");
        }
    }
}