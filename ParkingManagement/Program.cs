using System;
using ParkingManagement.ParkingCalculators;
using ParkingManagement.ParkingCalculators.Common;

namespace ParkingManagement
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome! to Parking Manager, please enter your preferred " +
                               "Charging options "
                               + Environment.NewLine +
                                "Currently We Support 2 Charging Options");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ShortStay and LongStay ");
            //Console.WriteLine(Environment.NewLine);
            Console.ResetColor();

            string input = Console.ReadLine().Trim().ToUpper();
            if (Enum.IsDefined(typeof(CalculatorType), input))
            {
                var calculatorType = Enum.Parse<CalculatorType>(input);
                // Preferred way DI
                CalculatorFactory<IParkingCalculator> factory =
                    new CalculatorFactory<IParkingCalculator>();

                var selectedCalculator = factory.CreateCalculator(calculatorType);
                var fee = new ParkingManager(selectedCalculator).CalculateParkingFee();
                Console.WriteLine($"Your Parking Fee is {fee}");
                Console.WriteLine("Thank you Visit us again, Press Any key to close the windows,");
            }
            else
            {
                Console.WriteLine("Wrong Calculator Passed");
            }

            Console.ReadKey();
        }
    }
}