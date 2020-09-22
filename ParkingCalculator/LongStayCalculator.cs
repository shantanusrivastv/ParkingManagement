using System;
using ParkingCalculator.Common;
using ParkingCalculator.DurationCalculators;
using ParkingManagement.Common;
using Validator = ParkingManagement.Common.Validator;

namespace ParkingCalculator
{
    public class LongStayCalculator : BaseCalculator, IParkingCalculator
    {
        private readonly IDurationCalculator<double> _durationCalculator;
        private readonly IValidator _validator;
        public CalculatorType CalculatorType => CalculatorType.LONGSTAY;

        // DI preferred
        public LongStayCalculator()
        {
            _validator = new Validator();
            _durationCalculator = new LongStayDurationCalculator();
        }

        public decimal CalculateParkingCharges(DateTime parkingDateTime, DateTime exitDateTime)
        {
            if (_validator.IsValidInput(parkingDateTime, exitDateTime))
            {
                var chargeableDuration = _durationCalculator.GetChargeableDuration(parkingDateTime, exitDateTime);
                ParkingChargePerUnit = ParkingConfig.LongStayPerDayFee;
                return base.CalculateFinalFee(chargeableDuration);
            }
            throw new ArgumentException("Parking Date cannot be greater than Exit date");
        }
    }
}