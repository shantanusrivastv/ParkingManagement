using System;

namespace ParkingManagement.ParkingCalculators
{
    public class BaseCalculator
    {
        protected decimal parkingChargePerUnit;

        protected virtual decimal CalculateFinalFee(double chargeableDuration)
        {
            var totalCharge = Convert.ToDecimal(chargeableDuration) * parkingChargePerUnit;
            return decimal.Round(totalCharge, 2);
        }
    }
}