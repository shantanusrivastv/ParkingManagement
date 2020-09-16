using System;

namespace ParkingManagement.Common
{
    public interface IValidator
    {
        bool IsValidInput(DateTime parkingDateTime, DateTime exitDateTime);
    }
}