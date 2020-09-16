using System;
using NUnit.Framework;

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
    }
}