using System;

namespace ParkingManagement.ParkingCalculators.DurationCalculators
{
    public interface IDurationCalculator<out T>
    {
        T GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime);
    }
}