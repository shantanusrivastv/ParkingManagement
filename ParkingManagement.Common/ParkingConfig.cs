using System;

namespace ParkingManagement.Common
{
    public static class ParkingConfig
    {
        public const decimal LongStayPerDayFee = 7.50m;
        public const decimal ShortStayPerMinFee = 1.10m / 60m;
        public const double FullDayDurationInMinutes = 600d;
        public static readonly TimeSpan StartClock = new TimeSpan(8, 0, 0);
        public static readonly TimeSpan EndClock = new TimeSpan(18, 0, 0);
    }
}