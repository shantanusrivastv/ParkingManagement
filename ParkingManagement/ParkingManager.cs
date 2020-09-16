using System;
using ParkingManagement.ParkingCalculators;

namespace ParkingManagement
{
    //Implemented Strategy Pattern injecting the Calculator we need to use.
    public class ParkingManager : IParkingManager
    {
        private readonly IParkingCalculator _parkingCalculator;

        //Hard Coded dates
        private readonly DateTime _parkingDateTime = DateTime.Now;
        private readonly DateTime _exitDateTime = DateTime.Now.AddDays(2).AddHours(1);

        public ParkingManager(IParkingCalculator parkingCalculator)
        {
            _parkingCalculator = parkingCalculator;
        }

        public decimal GetTotalParkingFee()
        {
            return _parkingCalculator.CalculateParkingCharges(_parkingDateTime, _exitDateTime);
        }
    }
}