using System;

namespace ParkingManagement.Common
{
    public class Validator : IValidator
    {
        public bool IsValidInput(DateTime parkingDateTime, DateTime exitDateTime)
        {
            return parkingDateTime < exitDateTime;
        }
    }
}