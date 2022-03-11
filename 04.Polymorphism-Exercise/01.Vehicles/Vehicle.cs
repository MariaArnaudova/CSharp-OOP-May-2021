using System;
using System.Collections.Generic;
using System.Text;

namespace _01.Vehicles
{
  public abstract class Vehicle 
    {
        protected  Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get;protected set; }
        public virtual double FuelConsumption { get; protected set; }

        public virtual void Drive(double distance)
        {
            FuelQuantity -= distance * FuelConsumption;
        }

        public virtual void Refuel(double fue)
        {
            FuelQuantity += fue;
        }
    }
}
