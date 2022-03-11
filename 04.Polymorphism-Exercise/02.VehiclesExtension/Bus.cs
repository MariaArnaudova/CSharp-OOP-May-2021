using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double ConditionerConsumption = 1.4;
        private double defaultFuelConsumption;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.defaultFuelConsumption = fuelConsumption;
        }
       
        public override double FuelConsumption { get; set; }

        public bool IsEmpty { get; set; }
    
        public override void Drive(double distance)
        {
            if (!IsEmpty)
            {
                this.FuelConsumption += ConditionerConsumption;
            }
            base.Drive(distance);

            this.FuelConsumption = defaultFuelConsumption;
        }
    }
}
