using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
   
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
        }
        public double TankCapacity { get; set; }
        public double FuelQuantity
        {
            get
            {
                return this.fuelQuantity;
            }
            set
            {
                if (value > this.TankCapacity)
                {
                    this.fuelQuantity = 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual double FuelConsumption { get; set; }
    
        public virtual void Drive(double distance)
        {
            double neededFuel = distance * FuelConsumption;
            if (neededFuel <= FuelQuantity)
            {
                this.fuelQuantity -= distance * FuelConsumption;
                Console.WriteLine($"{this.GetType().Name} travelled { distance} km");
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (amount + this.fuelQuantity > this.TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
            }
        
                FuelQuantity += amount;
        }      
    }
}
