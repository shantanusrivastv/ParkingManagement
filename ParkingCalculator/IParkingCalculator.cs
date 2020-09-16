using System;
using ParkingManagement.Common;

namespace ParkingCalculator
{
    public interface IParkingCalculator
    {
        decimal CalculateParkingCharges(DateTime parkingDateTime, DateTime exitDateTime);

        public CalculatorType CalculatorType { get; }
    }
}