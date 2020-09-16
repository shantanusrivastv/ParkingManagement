using System;

namespace ParkingManagement.ParkingCalculators.Common
{
    public class NotFoundCalculator : IParkingCalculator
    {
        public CalculatorType CalculatorType => CalculatorType.NOTDEFINED;

        public decimal ParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            throw new NotImplementedException("Requested Calcualtor not found ");
        }
    }
}