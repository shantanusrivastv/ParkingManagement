using System;
using ParkingCalculator.Common;

namespace ParkingVendorCalculator
{
    //Dummy Implemetation
    public class ContractorCalculator : ICalculator
    {
        //Need to define a better filter
        CalculatorType ICalculator.CalculatorType => CalculatorType.CONTRACTOR;

        public decimal CalculateParkingCharges()
        {
            return 1.0m;
        }
    }
}