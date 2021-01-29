using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark.Model.Vehicle
{
    class VehicleComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle v1, Vehicle v2)
        {
            return string.Compare(v1.ModelName, v2.ModelName);
        }
    }
}
