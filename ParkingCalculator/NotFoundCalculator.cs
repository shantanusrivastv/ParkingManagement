using System;

using ParkingCalculator.Common;

namespace ParkingCalculator
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