using System;
using Autopark.Model.Vehicle;
using Autopark.View;

namespace Autopark.Controller
{
    public class InheritanceController
    {
        public static void Start()
        {
            Printer.Print(InterfacesController.vehicles);

            Console.WriteLine("\nEquals vehicles by type and model: ");
            PrintEqualVehicle(InterfacesController.vehicles);
        }

        public static void PrintEqualVehicle(Vehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                for (int j = i + 1; j < vehicles.Length - 1; j++)
                {
                    if (vehicles[i].Equals(vehicles[j]))
                    {
                        Console.WriteLine(vehicles[i]);
                        Console.WriteLine(vehicles[j]);
                    }
                }
            }
        }
    }
}
