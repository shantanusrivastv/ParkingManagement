using System;
using NUnit.Framework;
using ParkingManagement.ParkingCalculators.DurationCalculators;

namespace ParkingManagement.Tests
{
    [TestFixture]
    public class LongStayDurationCalculatorTest
    {
        private LongStayDurationCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new LongStayDurationCalculator();
        }

        [TestCase("09/07/2017 07:50:00 ", "09/09/2017 05:20:00 ", 3)] //Original TestCase
        [TestCase("09/07/2017 07:50:00 ", "09/07/2017 07:50:01 ", 1)] //Same Day exit
        [TestCase("09/07/2017 07:50:00 ", "09/08/2017 00:00:01 ", 2)] //Edge Case next day
        [TestCase("09/07/2017 07:50:00 ", "09/08/2017 07:50:01 ", 2)] //Another Edge Case for next day
        [TestCase("09/07/2017 00:00:00 ", "09/07/2017 00:00:01 ", 1)] //Edge Case same day
        [TestCase("09/07/2017 00:00:00 ", "09/20/2017 00:00:01 ", 14)] //Long Day Parking
        public void Should_Return_Chargeable_Days_For_Long_Stay(DateTime parkingDateTime, DateTime exitDateTime, double expected)
        {
            var res = _sut.GetChargeableDuration(parkingDateTime, exitDateTime);
            Assert.AreEqual(expected, res);
        }
    }
}