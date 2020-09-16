using System;
using ParkingManagement.Extensions;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement.ParkingCalculators.DurationCalculators
{
    public class ShortStayDurationCalculator : IDurationCalculator<double>
    {
        public double GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime)
        {
            double totalChargeableMinutes;

            // Car is Parked for over a day
            if (exitDateTime.Date > parkingDateTime.Date)
            {
                var chargeableMinutesOnParkingDay = GetChargeableMinutesOnParkingDay(parkingDateTime);
                var chargeableMinutesForFullDays = GetChargeableMinutesForFullDays(parkingDateTime, exitDateTime);
                var chargeableMinutesOnExitDay = GetChargeableMinutesOnExitDay(exitDateTime);

                totalChargeableMinutes = chargeableMinutesOnParkingDay + chargeableMinutesForFullDays
                                         + chargeableMinutesOnExitDay;
            }
            else
            {
                var chargeableEntryTime = parkingDateTime.TimeOfDay < ParkingConfig.StartClock ?
                                                ParkingConfig.StartClock : parkingDateTime.TimeOfDay;

                var chargeableExitTime = exitDateTime.TimeOfDay > ParkingConfig.EndClock ?
                                                ParkingConfig.EndClock : exitDateTime.TimeOfDay;

                totalChargeableMinutes = chargeableExitTime < chargeableEntryTime ?
                                                   0d : (chargeableExitTime - chargeableEntryTime).TotalMinutes;
            }

            return totalChargeableMinutes;
        }

        public double GetChargeableMinutesOnParkingDay(DateTime parkingDateTime)
        {
            if (parkingDateTime.IsFreeParkingHoursForParkDate())
            {
                return 0d;
            }
            else
            {
                //Since Parked before startClock,for more than a day so full day fee
                return parkingDateTime.TimeOfDay < ParkingConfig.StartClock ? ParkingConfig.FullDayDurationInMinutes : (ParkingConfig.EndClock - parkingDateTime.TimeOfDay).TotalMinutes;
            }
        }

        public double GetChargeableMinutesOnExitDay(DateTime exitDateTime)
        {
            if (exitDateTime.IsFreeParkingHoursForExitDate())
            {
                return 0d;
            }
            else
            {
                //Since Exited after endClock for overnight parking so full day fee
                return exitDateTime.TimeOfDay > ParkingConfig.EndClock ?
                                    ParkingConfig.FullDayDurationInMinutes :
                                    (exitDateTime.TimeOfDay - ParkingConfig.StartClock).TotalMinutes;
            }
        }

        public int GetChargeableMiddleDays(DateTime from, DateTime end)
        {
            var totalDays = 0;
            //Get Non-weekend days between Parked Day and Exit Day
            for (var date = from.AddDays(1); date < end.AddDays(-1); date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    totalDays++;
            }

            return totalDays;
        }

        public double GetChargeableMinutesForFullDays(DateTime entryTime, DateTime exitTime)
        {
            var days = GetChargeableMiddleDays(entryTime, exitTime);
            return days * ParkingConfig.FullDayDurationInMinutes;
        }
    }
}