using System;
using NUnit.Framework;
using ParkingManagement.ParkingCalculators;

namespace ParkingManagement.Tests
{
    [TestFixture]
    public class LongStayCalculatorTest
    {
        private LongStayCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new LongStayCalculator();
        }

        [TestCase("09/07/2017 07:50:00 ", "09/09/2017 05:20:00 ", 22.50)] //Original TestCase
        [TestCase("09/07/2017 07:50:00 ", "09/07/2017 07:50:01 ", 7.50)] //Same Day exit
        [TestCase("09/07/2017 07:50:00 ", "09/08/2017 00:00:01 ", 15.00)] //Edge Case next day
        [TestCase("09/07/2017 00:00:00 ", "09/07/2017 00:00:01 ", 7.50)] //Edge Case same day
        public void Should_Calculate_LongStay_Parking_Charges(DateTime entryDate, DateTime exitDate, decimal expected)
        {
            var res = _sut.ParkingCharges(entryDate, exitDate);
            Assert.AreEqual(expected, res);
        }

        [TestCase("09/07/2020 07:50:00", "09/07/2020 06:20:00")]
        public void Should_Throw_Exception_For_InValid_Inputs(DateTime entryDateTime, DateTime exitDateTime)
        {
            var ex = Assert.Throws<ArgumentException>(() => _sut.ParkingCharges(entryDateTime, exitDateTime));
            Assert.That(ex.Message, Is.EqualTo("Parking Date cannot be greater than Exit date"));
        }
    }
}