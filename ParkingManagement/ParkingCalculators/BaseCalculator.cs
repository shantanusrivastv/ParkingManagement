using System;

namespace ParkingManagement.ParkingCalculators
{
    public class BaseCalculator
    {
        protected decimal ParkingChargePerUnit;

        protected virtual decimal CalculateFinalFee(double chargeableDuration)
        {
            var totalCharge = Convert.ToDecimal(chargeableDuration) * ParkingChargePerUnit;
            return decimal.Round(totalCharge, 2);
        }
    }
}