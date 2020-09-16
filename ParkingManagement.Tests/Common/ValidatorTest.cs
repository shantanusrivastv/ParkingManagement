using System;
using NUnit.Framework;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement.Tests.Common
{
    [TestFixture]
    public class ValidatorTest
    {
        private Validator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Validator();
        }

        [TestCase("09/07/2017 07:50:00 ", "09/09/2017 05:20:00 ", true)] //Original TestCase
        public void Should_Validate_Input(DateTime parkingDateTime, DateTime exitDateTime, bool expected)
        {
            Assert.IsTrue(_sut.IsValidInput(parkingDateTime, exitDateTime));
        }
    }
}