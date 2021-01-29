using System;
using Autopark.Model.Vehicle;
using Autopark.View;

namespace Autopark.Controller
{
    public class ClassesController
    {
        public static VehicleType[] types = new VehicleType[4] {
            new VehicleType(1, "Bus", 1.2),
            new VehicleType(2, "Car", 1),
            new VehicleType(3, "Rink", 1.5),
            new VehicleType(4, "Tractor", 1.2)
        };

        public static void Start()
        {
            types[3].TaxCoefficient = 1.3;

            DisplayTypes(types);
            Console.WriteLine($"\nMax coefficient = { FindMaxCoefficient(types) }");
            Console.WriteLine($"Average tax coefficient = { FindAverageTaxCoefficient(types) }");

            Console.WriteLine("\nVehicles to string: ");
            Printer.Print(types);
        }

        public static double FindMaxCoefficient(VehicleType[] types)
        {
            double max = types[0].TaxCoefficient;

            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].TaxCoefficient > max)
                    max = types[i].TaxCoefficient;
            }

            return max;
        }

        public static double FindAverageTaxCoefficient(VehicleType[] types)
        {
            double sum = 0;

            for (int i = 0; i < types.Length; i++)
            {
                sum += types[i].TaxCoefficient;
            }

            return sum / types.Length;
        }

        public static void DisplayTypes(VehicleType[] types)
        {
            foreach (var type in types)
                type.Display();
        }

        public static void PrintTypes(VehicleType[] types)
        {
            foreach (var type in types)
                Console.WriteLine(type.ToString());
        }
    }
}
