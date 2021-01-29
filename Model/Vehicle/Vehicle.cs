using System;
using System.Collections.Generic;
using Autopark.Model.Engine;

namespace Autopark.Model.Vehicle
{
    public class Vehicle : IComparable<Vehicle>
    {
        public int Id { get; }
        public VehicleType Type { get; }
        public string ModelName { get; set; }
        public string RegistrationNumber { get; set; }
        public double Weight { get; set; }
        public int ManufactureYear { get; }
        public double Mileage { get; set; }
        public double TankVolume { get; set; }
        public Colors Color { get; set; }
        public AbstractEngine Engine { get; set; }
        public List<Rent> CarRents { get; set; }

        public Vehicle()
        {

        }

        public Vehicle(int id, VehicleType type, string modelName, string registrationNumber, double weight, 
                int manufactureYear, double mileage, double tankVolume, Colors color, AbstractEngine engine, List<Rent> rents)
        {
            Id = id;
            Type = type;
            ModelName = modelName;
            RegistrationNumber = registrationNumber;
            Weight = weight;
            ManufactureYear = manufactureYear;
            Mileage = mileage;
            TankVolume = tankVolume;
            Color = color;
            Engine = engine;
            CarRents = rents;
        }

        public double GetCalcTaxPerMonth()
        {
            return (Weight * 0.0013) + (Engine.EngineTaxCoefficient * Type.TaxCoefficient * 30) + 5;
        }

        public double GetTotalIncome()
        {
            double income = 0;

            for (int i = 0; i < CarRents.Count; i++)
            {
                income += CarRents[i].RentalPrice;
            }

            return income;
        }

        public double GetTotalProfit()
        {
            return GetTotalIncome() - GetCalcTaxPerMonth();
        }

        public override string ToString()
        {
            return $"{Id}, {Type}, {ModelName}, {RegistrationNumber}, {Weight}, {ManufactureYear}, " +
                   $"{Mileage}, {TankVolume}, {Color}, {Type.TaxCoefficient}";
        }

        public int CompareTo(Vehicle secondVehicle)
        {
            if (secondVehicle != null)
            {
                return GetCalcTaxPerMonth().CompareTo(secondVehicle.GetCalcTaxPerMonth());
            }
            else
                throw new Exception("It is not possible to compare two objects");
        }

        public override bool Equals(object obj)
        {
            Vehicle vehicle = (Vehicle)obj;

            if (vehicle != null)
            {
                return Type.Equals(vehicle.Type) && ModelName.Equals(vehicle.ModelName);
            }
            else
                throw new Exception("It is not possible to compare two objects");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
