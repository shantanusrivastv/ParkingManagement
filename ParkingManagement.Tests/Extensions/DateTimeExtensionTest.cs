using System;
using NUnit.Framework;
using ParkingManagement.Extensions;

namespace ParkingManagement.Tests.Extensions
{
    [TestFixture]
    public class DateTimeExtensionTest
    {
        [TestCase("09/19/2020 16:50:00", true)] //Weekend is Free
        [TestCase("09/16/2020 16:50:00", false)] //Everyday in not Sunday
        [TestCase("09/16/2020 18:50:00", true)] //Happy hours are free
        [TestCase("09/16/2020 15:50:00", false)] //Parked within Chargeable Clock
        public void Should_Verifiy_Free_Parking_Hourse_For_Park_Date(DateTime parkDateTime, bool expected)
        {
            Assert.AreEqual(expected, parkDateTime.IsFreeParkingHoursForParkDate());
        }

        [TestCase("09/19/2020 16:50:00", true)] //Weekend is Free
        [TestCase("09/16/2020 16:50:00", false)] //Everyday in not Sunday
        [TestCase("09/16/2020 06:50:00", true)] //Happy hours are free
        [TestCase("09/16/2020 15:50:00", false)] //Exited within Chargeable Clock
        public void Should_Verifiy_Free_Parking_Hourse_For_Exit_Date(DateTime parkDateTime, bool expected)
        {
            Assert.AreEqual(expected, parkDateTime.IsFreeParkingHoursForExitDate());
        }
    }
}