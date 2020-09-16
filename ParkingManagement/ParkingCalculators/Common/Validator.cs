using System;

namespace ParkingManagement.ParkingCalculators.Common
{
    public class Validator : IValidator
    {
        public bool ValidateInput(DateTime parkingDateTime, DateTime exitDateTime)
        {
            return parkingDateTime < exitDateTime ? true
                          : throw new ArgumentException("Parking Date cannot be greater than Exit date");
        }
    }
}