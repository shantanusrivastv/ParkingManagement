using System;
using NUnit.Framework;

namespace ParkingManagement.Tests
{
    [TestFixture]
    public class ShortStayDurationCalculatorTest
    {
        private ShortStayCalculator _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new ShortStayCalculator();
        }
    }
}