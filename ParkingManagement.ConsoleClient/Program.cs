using System;
using ParkingManagement.Core;

namespace ParkingManagement.ConsoleClient
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Welcome! to Parking Manager Console Clientt, please enter your preferred " +
                              "Charging options "
                              + Environment.NewLine +
                              "Currently We Support 2 Charging Options");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("ShortStay and LongStay ");
            Console.ResetColor();

            string input = Console.ReadLine()?.Trim().ToUpper();

            try
            {
                var parkingFee = new Welcome().EnterParking(input);
                Console.WriteLine($"Your Parking Fee is {parkingFee}");
                Console.WriteLine("Thank you, Please Visit us again, Press Any key to close the windows,");
                Console.ReadKey();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine("Invalid Selection made, reder to error below for detials");
                Console.WriteLine(ex.Message);
            }
        }
    }
}