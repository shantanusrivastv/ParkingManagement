using System;
using ParkingCalculator.Common;

namespace ParkingCalculator
{
    public interface IParkingCalculator : ICalculator
    {
        decimal CalculateParkingCharges(DateTime parkingDateTime, DateTime exitDateTime);
    }
}