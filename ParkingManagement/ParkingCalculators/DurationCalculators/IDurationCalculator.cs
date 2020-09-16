using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement.ParkingCalculators.DurationDurationCalculators
{
    public interface IDurationCalculator<out T>
    {
        T GetChargeableDuration(DateTime parkingDateTime, DateTime exitDateTime);
    }
}