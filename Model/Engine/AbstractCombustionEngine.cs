﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Autopark.Model.Engine
{
    public abstract class AbstractCombustionEngine : AbstractEngine
    {
        public double FuelConsumptionPer100 { get; set; }
        public double EngineCapacity { get; set; }

        public AbstractCombustionEngine(string typeName, double engineTaxCoefficient) : base(typeName, engineTaxCoefficient)
        {

        }

        public override double GetMaxKilometers(double fuelTankCapacity)
        {
            return fuelTankCapacity * 100 / FuelConsumptionPer100;
        }
    }
}
