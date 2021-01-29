using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark.Model
{
    public class Rent
    {
        private int vehicleId;
        private DateTime rentalDate;
        private double rentalPrice;

        public Rent()
        {

        }

        public Rent(int id, DateTime rentalDate, double rentalPrice)
        {
            VehicleId = id;
            RentalDate = rentalDate;
            RentalPrice = rentalPrice;
        }

        public DateTime RentalDate { get => rentalDate; set => rentalDate = value; }
        public double RentalPrice { get => rentalPrice; set => rentalPrice = value; }
        public int VehicleId { get => vehicleId; set => vehicleId = value; }

        public override string ToString()
        {
            return $"{VehicleId}, {rentalDate.ToString("dd.MM.yyyy")}, {rentalPrice}";
        }
    }
}
