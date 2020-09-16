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
        public void Should_Return_Chargeable_Minutes_On_Park_Day_For_OverNight_Parking(DateTime parkDateTime, double expectedMinute)
        {
            var result = _sut.GetChargeableMinutesOnParkingDay(parkDateTime);
            Assert.AreEqual(expectedMinute, result);
        }
    }
}