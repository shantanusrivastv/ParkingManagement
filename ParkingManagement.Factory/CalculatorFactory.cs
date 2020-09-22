using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ParkingCalculator;
using ParkingManagement.Common;

namespace ParkingManagement.Factory
{
    //We could further abstract this to be used other than IParkingCalculator
    public class CalculatorFactory<T> : ICalculatorFactory<T> where T : class, IParkingCalculator
    {
        private static bool _hasbeenCalled;
        private static IEnumerable<T> CalculatorList { get; set; }

        private const string assemblySuffix = "Calculator";

        public T CreateCalculator(CalculatorType calculatorType)
        {
            if (!_hasbeenCalled)
            {
                var assemblyToLoad = Assembly.GetExecutingAssembly().GetReferencedAssemblies()
                                                .Where(x => x.Name.EndsWith(assemblySuffix))
                                                .SingleOrDefault();

                Assembly assembly = Assembly.Load(assemblyToLoad);

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