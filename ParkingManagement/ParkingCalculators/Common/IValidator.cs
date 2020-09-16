using System;

namespace ParkingManagement.ParkingCalculators.Common
{
    public interface IValidator
    {
        bool ValidateInput(DateTime parkingDateTime, DateTime exitDateTime);
    }
}