using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.ParkingCalculators.DurationDurationCalculators
{
    public class LongStayDurationCalculator : IDurationCalculator<double>
    {
        public double GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime)
        {
            // Car is Parked for over a day
            if (exitDateTime.Date > parkingDateTime.Date)
            {
                // Rounding up to whole days adding a day
                return Math.Ceiling((exitDateTime - parkingDateTime).TotalDays + 1d);
            }
            else
            {
                return 1d;
            }
        }
    }
}