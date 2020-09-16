using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement
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