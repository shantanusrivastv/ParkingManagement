using System;
using ParkingCalculator.Common;

namespace ParkingVendorCalculator.cs
{
    //Dummy Implemetation
    public class ContractorCalculator : ICalculator
    {
        //Need to define a better filter
        CalculatorType ICalculator.CalculatorType => CalculatorType.CONTRACTOR;

        public decimal CalculateParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            return 1.0m;
        }
    }
}