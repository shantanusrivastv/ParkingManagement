using System;
using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome! to Parking Manager, please enter your preferred " +
                               "Charging options "
                               + Environment.NewLine +
                                "Currently We Support 2 Charging Options");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ShortStay and LongStay ");
            Console.ResetColor();

            string input = Console.ReadLine()?.Trim().ToUpper();
            if (Enum.IsDefined(typeof(CalculatorType), input))
            {
                var calculatorType = Enum.Parse<CalculatorType>(input);
                // Preferred way DI
                var factory = new CalculatorFactory<IParkingCalculator>();

                var selectedCalculator = factory.CreateCalculator(calculatorType);
                var parkingFee = new ParkingManager(selectedCalculator).GetTotalParkingFee();
                Console.WriteLine($"Your Parking Fee is {parkingFee}");
                Console.WriteLine("Thank you, Please Visit us again, Press Any key to close the windows,");
            }
            else
            {
                Console.WriteLine("Wrong Calculator Passed");
            }

            Console.ReadKey();
        }
    }
}