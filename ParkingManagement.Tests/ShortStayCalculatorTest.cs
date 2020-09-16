using System;
using NUnit.Framework;
using ParkingManagement.ParkingCalculators;

namespace ParkingManagement.Tests
{
    [TestFixture]
    public class ShortStayCalculatorTest
    {
        private ShortStayCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ShortStayCalculator();
        }

        [TestCase("09/07/2017 16:50:00", "09/09/2017 19:15:00", 12.28)] //Original Test Case
        [TestCase("09/15/2020 05:00:00", "09/21/2020 17:58:00", 54.96)]//Parking over weekend
        [TestCase("09/15/2020 08:00:00", "09/15/2020 08:02:00", 0.04)]//Edge Case for Park Date
        [TestCase("09/15/2020 05:00:00", "09/15/2020 07:59:00", 0.00)]//Edge Case for Park Date
        [TestCase("09/15/2020 17:59:00", "09/15/2020 18:01:00", 0.02)]//Edge Case for Exit Date
        [TestCase("09/15/2020 18:00:00", "09/15/2020 18:01:00", 0.00)]//Edge Case for Exit Date
        [TestCase("09/18/2020 18:00:00", "09/19/2020 07:59:00", 0.00)]//Edge Case for weekend Parking
        [TestCase("09/18/2020 18:00:00", "09/19/2020 08:59:00", 0.00)]//Edge Case for weekend Parking
        [TestCase("09/26/2020 18:00:00", "09/27/2020 08:59:00", 0.00)]//Weekend Parking
        [TestCase("09/26/2020 18:00:00", "09/28/2020 08:00:00", 0.00)]//Edge Case weekend Parking and Park Date
        [TestCase("09/26/2020 18:00:00", "09/28/2020 18:00:00", 11)]//Edge Case weekend Parking and Exit Date
        [TestCase("09/26/2020 18:00:00", "09/28/2020 08:01:00", 0.02)]//Weekend Parking with paid Park Date
        public void Should_Return_ShortStay_Parking_Charges(DateTime entryDate, DateTime exitDate, decimal expected)
        {
            var res = _sut.CalculateParkingCharges(entryDate, exitDate);
            Assert.AreEqual(expected, res);
        }

        [TestCase("09/07/2020 07:50:00", "09/07/2020 06:20:00")]
        public void Should_Throw_Exception_For_InValid_Inputs(DateTime entryDateTime, DateTime exitDateTime)
        {
            var ex = Assert.Throws<ArgumentException>(() => _sut.CalculateParkingCharges(entryDateTime, exitDateTime));
            Assert.That(ex.Message, Is.EqualTo("Parking Date cannot be greater than Exit date"));
        }
    }
}