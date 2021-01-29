using System;
using Autopark.Model.Vehicle;
using Autopark.View;

namespace Autopark.Controller
{
    public class AbstarctionController
    {
        public static void Start()
        {
            Vehicle[] vehicles = InterfacesController.vehicles;

            Printer.Print(vehicles);

            Console.WriteLine("\nThe max number of km of each vehicle:");
            GetAllMaxKilometers(vehicles);

            Vehicle maxKmVehicle = FindMaxKilometers(vehicles);
            Console.WriteLine($"\nVehicle that rode max kilometers with full tank: {maxKmVehicle.ModelName} " +
                $"{maxKmVehicle.Engine.GetMaxKilometers(maxKmVehicle.TankVolume).ToString("0.00")} km");
        }

        public static Vehicle FindMaxKilometers(Vehicle[] vehicles)
        {
            double max = vehicles[0].Engine.GetMaxKilometers(vehicles[0].TankVolume);
            int index = 0;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].Engine.GetMaxKilometers(vehicles[i].TankVolume) > max)
                {
                    max = vehicles[i].Engine.GetMaxKilometers(vehicles[i].TankVolume);
                    index = i;
                }
            }

            return vehicles[index];
        }

        public static void GetAllMaxKilometers(Vehicle[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                Console.WriteLine($"{vehicles[i].ModelName, -20} " +
                $"{vehicles[i].Engine.GetMaxKilometers(vehicles[i].TankVolume).ToString("0.00")} km");
            }
        }
    }
}
