using System;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement.ParkingCalculators
{
    public interface IParkingCalculator
    {
        decimal ParkingCharges(DateTime parkingDateTime, DateTime exitDateTime);

        public CalculatorType CalculatorType { get; }
    }
}