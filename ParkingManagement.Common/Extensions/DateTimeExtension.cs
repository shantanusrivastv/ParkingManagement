using System;

namespace ParkingManagement.Common.Extensions
{
    public static class DateTimeExtension
    {
        // Would Expose Publicly if required multiple places
        private static bool IsWeekend(this DateTime dateTime)
        {
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static bool IsFreeParkingHoursForParkDate(this DateTime dateTime)
        {
            return dateTime.TimeOfDay > ParkingConfig.EndClock || IsWeekend(dateTime);
        }

        public static bool IsFreeParkingHoursForExitDate(this DateTime dateTime)
        {
            return dateTime.TimeOfDay < ParkingConfig.StartClock || IsWeekend(dateTime);
        }
    }
}