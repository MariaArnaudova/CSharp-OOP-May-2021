using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double ConditionerConsumption = 1.6;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + ConditionerConsumption;
        public override void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (amount + this.FuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                FuelQuantity += amount * 0.95;
            }

        }
    }
}
