using System;
using System.Collections.Generic;
using System.Linq;
using ParkingCalculator.Common;

namespace ParkingManagement.Factory
{
    //We could further abstract this to be used other than IParkingCalculator
    public class CalculatorFactory<T> : ICalculatorFactory<T> where T : class, ICalculator
    {
        private static bool _hasbeenCalled;
        private static IEnumerable<T> CalculatorList { get; set; }

        private const string assemblyPrefix = "ParkingCalculator";

        public T CreateCalculator(CalculatorType calculatorType)
        {
            if (!_hasbeenCalled)
            {
                var assmblyList = AppDomain.CurrentDomain.GetAssemblies().ToList();
                var assembly = assmblyList.Where(x => x.FullName.Split(",")[0] == assemblyPrefix)
                                               .FirstOrDefault();

                var calculatorList = assembly.GetTypes()
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