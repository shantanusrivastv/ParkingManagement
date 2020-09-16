using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement
{
    //We could further abstract this to be used other than IParkingCalculator
    public class CalculatorFactory<T> : ICalculatorFactory<T> where T : class, IParkingCalculator
    {
        private static bool _hasbeenCalled;
        private static IEnumerable<T> CalculatorList { get; set; }

        public T CreateCalculator(CalculatorType calculatorType)
        {
            if (!_hasbeenCalled)
            {
                var calculatorList = Assembly.GetExecutingAssembly().GetTypes()
                                           .Where(x => (typeof(T).IsAssignableFrom(x) &&
                                                  !x.IsAbstract && !x.IsInterface))
                                            .ToList();

                //Creating a list for reuse
                CalculatorList = calculatorList.Select(x => Activator.CreateInstance(x) as T).ToList();
                _hasbeenCalled = true;
            }

            return CalculatorList.SingleOrDefault(x => x.CalculatorType == calculatorType) ??
                                CalculatorList.Where(x => x.CalculatorType == CalculatorType.NOTDEFINED) as T;
        }
    }
}