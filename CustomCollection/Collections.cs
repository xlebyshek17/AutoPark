using System;
using System.Collections.Generic;
using Autopark.Model.Vehicle;
using Autopark.Model;
using Autopark.Creator;
using Autopark.View;

namespace Autopark.CustomCollection
{
    public class Collections
    {
        private readonly char[] SEPARATOR = new char[] { '\n', '\r' };
        public List<VehicleType> Types { get; }
        public List<Vehicle> Vehicles { get; }
        public List<Rent> Rents { get; }

        public Collections(string typesPath, string vehiclePath, string rentsPath)
        {
            Types = LoadTypes(typesPath);
            Rents = LoadRents(rentsPath);
            Vehicles = LoadVehicles(vehiclePath);
        }

        public List<VehicleType> LoadTypes(string fileName)
        {
            string[] lines = LoadFile.GetStrings(LoadFile.CreatePath(fileName), SEPARATOR);
            List<VehicleType> vehicleTypes = new List<VehicleType>();

            foreach (var line in lines)
            {
                vehicleTypes.Add(CreateModels.CreateType(line));
            }

            return vehicleTypes;
        }

        public List<Vehicle> LoadVehicles(string fileName)
        {
            string[] lines = LoadFile.GetStrings(LoadFile.CreatePath(fileName), SEPARATOR);
            List<Vehicle> vehicles = new List<Vehicle>();

            foreach (var line in lines)
            {
                vehicles.Add(CreateModels.CreateVehicle(line, Types, Rents));
            }

            return vehicles;
        }

        public List<Rent> LoadRents(string fileName)
        {
            string[] lines = LoadFile.GetStrings(LoadFile.CreatePath(fileName), SEPARATOR);
            List<Rent> rents = new List<Rent>();

            foreach (var line in lines)
            {
                rents.Add(CreateModels.CreateRent(line));
            }

            return rents;
        }

        public void Insert(int index, Vehicle v)
        {
            if (index >= 0)
                Vehicles.Insert(index, v);
            else
                Vehicles.Add(v);
        }

        public int Delete(int index)
        {
            if (index >= 0)
            {
                Vehicles.RemoveAt(index);
                return index;
            }
            else
                return -1;
        }

        public double SumTotalProfit()
        {
            double sum = 0;

            foreach (var v in Vehicles)
                sum += v.GetTotalProfit();

            return sum;
        }

        /// <summary>
        /// Sort by ModelName
        /// </summary>
        public void Sort()
        {
            Vehicles.Sort(new VehicleComparer());
        }

        public void Print()
        {
            Printer.PrintVehicles(Vehicles);
            Console.WriteLine("{0,-5}{1,119}", "Total: ", SumTotalProfit().ToString("0.00"));
        }
    }
}