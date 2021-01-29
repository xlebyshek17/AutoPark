using System;
using System.Collections.Generic;
using Autopark.Model.Engine;
using Autopark.Model.Vehicle;
using Autopark.Model;
using Autopark.View;

namespace Autopark.Controller
{
    public class InterfacesController
    {
        public static Vehicle[] vehicles = new Vehicle[7]
        {
            new Vehicle(1, ClassesController.types[0], "Volkswagen Crafter", "5427 AX-7", 2022, 2015, 376000, 75, Colors.Blue, new GasolineEngine(2, 8.1), new List<Rent>()),
            new Vehicle(2, ClassesController.types[0], "Volkswagen Crafter", "6427 AA-7", 2500, 2014, 227010, 75, Colors.White, new GasolineEngine(2.18, 8.5), new List<Rent>()),
            new Vehicle(3, ClassesController.types[0], "Electric Bus E321", "6785 BA-7", 12080, 2019, 20451, 150, Colors.Green, new ElectricalEngine(50), new List<Rent>()),
            new Vehicle(4, ClassesController.types[1], "Golf 5", "8682 AX-7", 1200, 2006, 230451, 55, Colors.Gray, new DieselEngine(1.6, 7.2), new List<Rent>()),
            new Vehicle(5, ClassesController.types[1], "Tesla Model S 70D", "E001 AA-7", 2200, 2019, 10454, 70, Colors.Blue, new ElectricalEngine(25), new List<Rent>()),
            new Vehicle(6, ClassesController.types[2], "Hamm HD 12 VV", null, 3000, 2016, 122, 20, Colors.Yellow, new DieselEngine(3.2, 25), new List<Rent>()),
            new Vehicle(7, ClassesController.types[3], "MTZ Belarus-1025.4", "1145 AB-7", 1200, 2020, 109, 135, Colors.Red, new DieselEngine(4.75, 20.1), new List<Rent>())
        };
        public static void Start()
        {
            Console.WriteLine("Before sort: ");
            Printer.Print(vehicles);

            Console.WriteLine("\nAfter sort by tax per month:");
            Array.Sort(vehicles);
            Printer.Print(vehicles);

            Console.WriteLine($"\nVehicle with min mileage: {FindMinMileage(vehicles).ModelName} {FindMinMileage(vehicles).Mileage} km");
            Console.WriteLine($"Vehicle with max mileage: {FindMaxMileage(vehicles).ModelName} {FindMaxMileage(vehicles).Mileage} km");
        }

        public static Vehicle FindMaxMileage(Vehicle[] vehicles)
        {
            double maxMileage = vehicles[0].Mileage;
            int index = 0;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].Mileage > maxMileage)
                {
                    maxMileage = vehicles[i].Mileage;
                    index = i;
                }
            }

            return vehicles[index];
        }

        public static Vehicle FindMinMileage(Vehicle[] vehicles)
        {
            double minMileage = vehicles[0].Mileage;
            int index = 0;

            for (int i = 0; i < vehicles.Length; i++)
            {
                if (vehicles[i].Mileage < minMileage)
                {
                    minMileage = vehicles[i].Mileage;
                    index = i;
                }
            }

            return vehicles[index];
        }
    }
}
