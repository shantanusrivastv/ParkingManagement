using System;

namespace ParkingManagement.ParkingCalculators
{
    public interface IParkingCalculator
    {
        decimal ParkingCharges(DateTime parkingDateTime, DateTime exitDateTime);
    }
}