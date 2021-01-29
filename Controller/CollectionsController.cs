using System;
using System.Collections.Generic;
using Autopark.CustomCollection;
using Autopark.Model.Vehicle;
using Autopark.Model.Engine;
using Autopark.Model;

namespace Autopark.Controller
{
    public static class CollectionsController
    {
        private const string TYPES_PATH = "types.csv";
        private const string VEHICLE_PATH = "vehicles.csv";
        private const string RENT_PATH = "rents.csv";

        public static Collections vehicleCollection;

        public static void Start()
        {
            vehicleCollection = new Collections(TYPES_PATH, VEHICLE_PATH, RENT_PATH);

            vehicleCollection.Print();
            vehicleCollection.Insert(-1, AddNewVehicle()); // add new vehicle
            vehicleCollection.Delete(1);
            vehicleCollection.Delete(4);
            Console.WriteLine("\nCollection after modify:");
            vehicleCollection.Print();
            vehicleCollection.Sort();
            Console.WriteLine("\nCollection after sort by model name:");
            vehicleCollection.Print();
        }

        public static Vehicle AddNewVehicle()
        {
            int id = vehicleCollection.Vehicles.Count + 1;
            VehicleType type = vehicleCollection.Types[1];

            return new Vehicle(id, type, "Audi Q3 Sportback", "9999 AX-7", 2000, 2020, 13000, 60, Colors.Red, new DieselEngine(2.25, 7.5), new List<Rent>());
        }
        
    }
}
