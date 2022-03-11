using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Truck : Vehicle
    {
        private const double ConditionerConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + ConditionerConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + ConditionerConsumption;
        public override void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel <= FuelQuantity)
            {
                base.FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled { distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
        public override void Refuel(double fue)
        {
            base.Refuel(fue * 0.95);
        }
        //FuelQuantity += fue* 0.95;
    }
}
