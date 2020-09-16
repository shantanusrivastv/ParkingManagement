using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingManagement
{
    public interface IParkingCalculator
    {
        decimal ParkingCharges(DateTime parkingDateTime, DateTime exitDateTime);
    }
}