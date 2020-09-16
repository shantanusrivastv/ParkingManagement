using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.Extensions;
using ParkingManagement.ParkingCalculators.Common;
using ParkingManagement.ParkingCalculators.DurationDurationCalculators;

namespace ParkingManagement.ParkingCalculators
{
    public class ShortStayDurationCalculator : IDurationCalculator<double>
    {
        public double GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime)
        {
            throw new NotImplementedException();
        }

        public double GetChargeableMinutesOnParkingDay(DateTime entryTime)
        {
            if (entryTime.IsFreeParkingHoursForParkDate())
            {
                return 0d;
            }
            else
            {
                //Since Parked before startClock,for more than a day so full day fee
                return entryTime.TimeOfDay < ParkingConfig.StartClock ? ParkingConfig.FullDayDurationInMinutes : (ParkingConfig.EndClock - entryTime.TimeOfDay).TotalMinutes;
            }
        }
    }
}