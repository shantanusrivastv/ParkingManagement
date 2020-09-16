using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement
{
    public class CalculatorFactory<T> : ICalculatorFactory<T> where T : class, IParkingCalculator
    {
        private static bool _hasInitialised;
        private static IEnumerable<T> CalculatorList { get; set; }

        public T CreateCalculator(CalculatorType commandType)
        {
            if (!_hasInitialised)
            {
                var calculatorList = Assembly.GetExecutingAssembly().GetTypes()
                                           .Where(x => (typeof(T).IsAssignableFrom(x) &&
                                                  !x.IsAbstract && !x.IsInterface))
                                            .ToList();

                //Creating a list for reuse
                CalculatorList = calculatorList.Select(x => Activator.CreateInstance(x) as T).ToList();
                _hasInitialised = true;
            }

            return (dynamic)CalculatorList.Where(x => x.CalculatorType == commandType).SingleOrDefault() ??
                            CalculatorList.Where(x => x.CalculatorType == CalculatorType.NOTDEFINED);
        }
    }
}