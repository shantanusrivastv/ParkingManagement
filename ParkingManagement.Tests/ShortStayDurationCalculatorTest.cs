using System;
using NUnit.Framework;
using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement.Tests
{
    [TestFixture]
    public class ShortStayDurationCalculatorTest
    {
        private ShortStayDurationCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ShortStayDurationCalculator();
        }

        [TestCase("09/07/2017 18:50:00", 0)] //Parking On Non-Chargeable period
        [TestCase("09/07/2017 06:50:00", ParkingConfig.FullDayDurationInMinutes)] // Parking Before Start Clock
        [TestCase("09/07/2017 09:00:00", 9d * 60d)] // Parking After Start Clock
        public void Should_Return_Chargeable_Minutes_On_ParkDay_For_OverNight_Parking(DateTime parkDateTime, double expectedMinute)
        {
            var result = _sut.GetChargeableMinutesOnParkingDay(parkDateTime);
            Assert.AreEqual(expectedMinute, result);
        }

        [TestCase("09/07/2017 05:50:00", 0)] //Exit On Non-Chargeable period
        [TestCase("09/07/2017 18:50:00", ParkingConfig.FullDayDurationInMinutes)] // Exiting After Stop Clock
        [TestCase("09/07/2017 09:00:00", 1d * 60d)] // Exit After Start Clock
        public void Should_Return_Chargeable_Minutes_On_ExitDay_For_OverNight_Parking(DateTime parkDateTime, double expectedMinute)
        {
            var result = _sut.GetChargeableMinutesOnExitDay(parkDateTime);
            Assert.AreEqual(expectedMinute, result);
        }

        [TestCase("09/07/2017 16:50:00", "09/09/2017 19:15:00", 1)]
        [TestCase("09/07/2017 16:50:00", "09/09/2017 19:15:00", 1)]
        [TestCase("09/15/2020 16:50:00", "09/20/2020 19:15:00", 3)]
        [TestCase("09/15/2020 16:50:00", "09/15/2020 19:16:00", 0)]
        [TestCase("09/15/2020 16:50:00", "09/16/2020 19:16:00", 0)]
        [TestCase("09/15/2020 16:50:00", "09/17/2020 19:16:00", 1)]
        public void Should_Return_Chargeable_MidDays_For_OverNight_Parking(DateTime entryDate, DateTime exitDate, int expected)
        {
            var res = _sut.GetChargeableMiddleDays(entryDate, exitDate);
            Assert.AreEqual(expected, res);
        }

        [TestCase("09/07/2017 16:50:00", "09/09/2017 19:15:00", ParkingConfig.FullDayDurationInMinutes * 1)]
        [TestCase("09/07/2017 16:50:00", "09/09/2017 19:15:00", ParkingConfig.FullDayDurationInMinutes * 1)]
        [TestCase("09/15/2020 16:50:00", "09/20/2020 19:15:00", ParkingConfig.FullDayDurationInMinutes * 3)]
        [TestCase("09/15/2020 16:50:00", "09/15/2020 19:16:00", 0)]
        [TestCase("09/15/2020 16:50:00", "09/16/2020 19:16:00", 0)]
        [TestCase("09/15/2020 16:50:00", "09/17/2020 19:16:00", ParkingConfig.FullDayDurationInMinutes * 1)]
        public void Should_Return_Chargeable_Minutes_For_Full_Middle_Days_With_OverNight_Parking(DateTime entryDate, DateTime exitDate, double expected)
        {
            var res = _sut.GetChargeableMinutesForFullDays(entryDate, exitDate);
            Assert.AreEqual(expected, res);
        }

        [TestCase("09/07/2017 16:50:00", "09/09/2017 19:15:00", 670d)] //Original Test Case
        [TestCase("09/15/2020 05:00:00", "09/21/2020 17:58:00", 2998d)]//Parking over weekend
        [TestCase("09/15/2020 08:00:00", "09/15/2020 08:02:00", 2d)]//Edge Case for Park Date
        [TestCase("09/15/2020 05:00:00", "09/15/2020 07:59:00", 0)]//Edge Case for Park Date
        [TestCase("09/15/2020 17:59:00", "09/15/2020 18:01:00", 1d)]//Edge Case for Exit Date
        [TestCase("09/15/2020 18:00:00", "09/15/2020 18:01:00", 0.00)]//Edge Case for Exit Date
        [TestCase("09/18/2020 18:00:00", "09/19/2020 07:59:00", 0.00)]//Edge Case for weekend Parking
        [TestCase("09/18/2020 18:00:00", "09/19/2020 08:59:00", 0.00)]//Edge Case for weekend Parking
        [TestCase("09/26/2020 18:00:00", "09/27/2020 08:59:00", 0.00)]//Weekend Parking
        [TestCase("09/26/2020 18:00:00", "09/28/2020 08:00:00", 0.00)]//Edge Case weekend Parking and Park Date
        [TestCase("09/26/2020 18:00:00", "09/28/2020 18:00:00", 600d)]//Edge Case weekend Parking and Exit Date
        [TestCase("09/26/2020 18:00:00", "09/28/2020 08:01:00", 1d)]//Weekend Parking with paid Park Date
        public void Should_Get_Total_Chargeable_Duration_In_Minutes(DateTime entryDate, DateTime exitDate, double expected)
        {
            var res = _sut.GetChargeableDuration(entryDate, exitDate);
            Assert.AreEqual(expected, res);
        }
    }
}