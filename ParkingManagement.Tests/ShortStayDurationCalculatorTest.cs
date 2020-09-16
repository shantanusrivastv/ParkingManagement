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
    }
}