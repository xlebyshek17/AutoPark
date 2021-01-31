using System;
using System.Collections.Generic;
using System.IO;
using Autopark.Model.Vehicle;
using Autopark.Model;
using Autopark.Model.Engine;
using System.Linq;

namespace Autopark.Creator
{
    public class CreateModels
    {
        public static VehicleType CreateType(string csvString)
        {
            var fields = GetFields(csvString);

            return new VehicleType(int.Parse(fields[0]), fields[1], double.Parse(fields[2]));
        }

        public static Rent CreateRent(string csvString)
        {
            var fields = GetFields(csvString);

            return new Rent(int.Parse(fields[0]), DateTime.Parse(fields[1]), double.Parse(fields[2]));
        }
        
        public static Vehicle CreateVehicle(string csvString, List<VehicleType> types, List<Rent> rents)
        {
            var fields = GetFields(csvString);

            Vehicle vehicle = new Vehicle(
                id: int.Parse(fields[0]),
                type: types.First(type => type.Id == int.Parse(fields[1])), 
                modelName: fields[2],
                registrationNumber: fields[3],
                weight: double.Parse(fields[4]),
                manufactureYear: int.Parse(fields[5]),
                mileage: double.Parse(fields[6]),
                tankVolume: double.Parse(fields[7]),
                color: Enum.Parse<Colors>(fields[8]),
                engine: GetEngine(Enum.Parse<EngineNames>(fields[9]), double.Parse(fields[10]), double.Parse(fields[11])),
                rents: rents.Where(rent => rent.VehicleId == int.Parse(fields[0])).ToList()
                );

            return vehicle;
        }

        public static AbstractEngine GetEngine(EngineNames name, double capacity, double consumption)
        {
            switch (name)
            {
                case EngineNames.Gasoline:
                    return new GasolineEngine(capacity, consumption);
                case EngineNames.Diesel:
                    return new DieselEngine(capacity, consumption);
                case EngineNames.Electrical:
                    return new ElectricalEngine(consumption);
            }

            throw new ArgumentOutOfRangeException();
        }

        public static string[] GetFields(string csvString)
        {
            return csvString.Split(',', StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
