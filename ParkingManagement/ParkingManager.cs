using System;
using ParkingManagement.ParkingCalculators;

namespace ParkingManagement
{
    public class ParkingManager : IParkingManager
    {
        private readonly IParkingCalculator _parkingCalculator;

        //Hard Coding
        private DateTime _parkingDateTime = DateTime.Now;
        private DateTime _exitDateTime = DateTime.Now.AddDays(2).AddHours(1);

        public ParkingManager(IParkingCalculator parkingCalculator)
        {
            _parkingCalculator = parkingCalculator;
        }

        public decimal CalculateParkingFee()
        {
            return _parkingCalculator.ParkingCharges(_parkingDateTime, _exitDateTime);
        }
    }
}