using System;
using ParkingManagement.ParkingCalculators.Common;
using ParkingManagement.ParkingCalculators.DurationCalculators;

namespace ParkingManagement.ParkingCalculators
{
    public class ShortStayCalculator : BaseCalculator, IParkingCalculator
    {
        private readonly IDurationCalculator<double> _durationCalculator;
        private readonly IValidator _validator;

        public CalculatorType CalculatorType => CalculatorType.SHORTSTAY;

        // DI preferred
        public ShortStayCalculator()
        {
            _validator = new Validator();
            _durationCalculator = new ShortStayDurationCalculator();
        }

        public decimal CalculateParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            if (_validator.IsValidInput(parkingDateTime, exitDateTime))
            {
                var chargeableDuration = _durationCalculator.GetChargeableDuration(parkingDateTime, exitDateTime);
                ParkingChargePerUnit = ParkingConfig.ShortStayPerMinFee;
                return base.CalculateFinalFee(chargeableDuration);
            }
            throw new ArgumentException("Parking Date cannot be greater than Exit date");
        }
    }
}