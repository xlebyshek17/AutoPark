using Autopark.Model.Vehicle;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark.View
{
    public static class Printer
    {
        public static void Print<T>(T[] list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static void PrintVehicles(List<Vehicle> vehicles)
        {
            Console.WriteLine(string.Format("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                                            "Id", "Type", "ModelName", "Number", "Weight(kg)", "Year", "Mileage", "Color",
                                            "Income", "Tax", "Profit"));
            foreach (var vehicle in vehicles)
                Console.WriteLine(string.Format("{0,-5}{1,-10}{2,-25}{3,-15}{4,-15}{5,-10}{6,-10}{7,-10}{8,-10}{9,-10}{10,-10}",
                                  vehicle.Id, vehicle.Type.TypeName, vehicle.ModelName, vehicle.RegistrationNumber, vehicle.Weight,
                                  vehicle.ManufactureYear, vehicle.Mileage, vehicle.Color, vehicle.GetTotalIncome().ToString("0.00"),
                                  vehicle.GetCalcTaxPerMonth().ToString("0.00"), vehicle.GetTotalProfit().ToString("0.00")));
        }
    }
}
