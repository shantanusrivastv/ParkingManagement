using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkingManagement.ParkingCalculators.Common;
using ParkingManagement.ParkingCalculators.DurationDurationCalculators;

namespace ParkingManagement
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
            if (_validator.ValidateInput(parkingDateTime, exitDateTime))
            {
                var chargeableDuration = _durationCalculator.GetChargeableDuration(parkingDateTime, exitDateTime);
                parkingChargePerUnit = ParkingConfig.LongStayPerDayFee;
                return base.CalculateFinalFee(chargeableDuration);
            }
            throw new ArgumentException("Invalid Argument Passed");
        }
    }
}