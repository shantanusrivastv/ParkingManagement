using System;
using ParkingManagement.ParkingCalculators.Common;
using ParkingManagement.ParkingCalculators.DurationCalculators;

namespace ParkingManagement.ParkingCalculators
{
    public class ShortStayCalculator : BaseCalculator, IParkingCalculator
    {
        private readonly IDurationCalculator<double> _durationCalculator;
        private readonly IValidator _validator;

        //todo DI
        public ShortStayCalculator()
        {
            _validator = new Validator();
            _durationCalculator = new ShortStayDurationCalculator();
        }

        public decimal ParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            if (_validator.IsValidInput(parkingDateTime, exitDateTime))
            {
                var chargeableDuration = _durationCalculator.GetChargeableDuration(parkingDateTime, exitDateTime);
                parkingChargePerUnit = ParkingConfig.ShortStayPerMinFee;
                return base.CalculateFinalFee(chargeableDuration);
            }
            throw new ArgumentException("Parking Date cannot be greater than Exit date");
        }
    }
}