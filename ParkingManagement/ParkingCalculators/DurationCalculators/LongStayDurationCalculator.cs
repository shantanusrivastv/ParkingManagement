using System;

namespace ParkingManagement.ParkingCalculators.DurationCalculators
{
    public class LongStayDurationCalculator : IDurationCalculator<double>
    {
        public double GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime)
        {
            // Car is Parked for over a day
            if (exitDateTime.Date > parkingDateTime.Date)
            {
                // The exact Time Difference is not required if its new date
                // fee for whole day will be charged
                return (exitDateTime.Date - parkingDateTime.Date).Days + 1d;
            }
            else
            {
                return 1d;
            }
        }
    }
}