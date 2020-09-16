using System;
using ParkingManagement.ParkingCalculators.Common;
using ParkingManagement.ParkingCalculators.DurationCalculators;

namespace ParkingManagement.ParkingCalculators
{
    public class LongStayCalculator : BaseCalculator, IParkingCalculator
    {
        private readonly IDurationCalculator<double> _durationCalculator;
        private readonly IValidator _validator;

        //todo DI
        public LongStayCalculator()
        {
            _validator = new Validator();
            _durationCalculator = new LongStayDurationCalculator();
        }

        public decimal ParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            if (_validator.IsValidInput(parkingDateTime, exitDateTime))
            {
                var chargeableDuration = _durationCalculator.GetChargeableDuration(parkingDateTime, exitDateTime);
                parkingChargePerUnit = ParkingConfig.LongStayPerDayFee;
                return base.CalculateFinalFee(chargeableDuration);
            }
            throw new ArgumentException("Parking Date cannot be greater than Exit date");
        }
    }
}