using System;

namespace ParkingManagement.ParkingCalculators.Common
{
    public interface IValidator
    {
        bool IsValidInput(DateTime parkingDateTime, DateTime exitDateTime);
    }
}