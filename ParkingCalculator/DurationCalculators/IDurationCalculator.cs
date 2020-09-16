using System;

namespace ParkingCalculator.DurationCalculators
{
    public interface IDurationCalculator<out T>
    {
        T GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime);
    }
}