using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
    public class Car :Vehicle
    {
        private const double ConditionerConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption )
        {
        }

        public override double FuelConsumption => base.FuelConsumption + ConditionerConsumption;
        public override void Drive(double distance)
        {

            double neededFuel = distance * FuelConsumption;
            if (neededFuel<=FuelQuantity)
            {
             FuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled { distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }
       
    }
}
