using System;
using System.Collections.Generic;

namespace _01.Vehicles
{
    class Program
    {
        static void Main(string[] args)
        {
            //: "Car {fuel quantity} {liters per km}"
            //Truck { fuel quantity} { liters per km}
            List<Vehicle> vehicles = new List<Vehicle>();

            string[] carData = Console.ReadLine().Split();

            string typeVehicle = carData[0];
            double carFuelQuantity = double.Parse(carData[1]);
            double truckFuelConsumption = double.Parse(carData[2]);

            Vehicle car = new Car(carFuelQuantity, truckFuelConsumption);
            vehicles.Add(car);


            string[] truckData = Console.ReadLine().Split();

            string typeName = truckData[0];
            double fuelQuantity = double.Parse(truckData[1]);
            double fuelConsumption = double.Parse(truckData[2]);

            Vehicle truck = new Truck(fuelQuantity, fuelConsumption);
            vehicles.Add(truck);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string vehicle = tokens[1];
                double distance = double.Parse(tokens[2]);

                if (command == "Drive")
                {
                    if (vehicle =="Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicle=="Truck")
                    {
                        truck.Drive(distance);
                    }
                }
                else if (command == "Refuel")
                {
                    if (vehicle == "Car")
                    {
                        car.Refuel(distance);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Refuel(distance);
                    }
                }
            }

            Console.WriteLine($"{car.GetType().Name}: { car.FuelQuantity:f2}");
            Console.WriteLine($"{truck.GetType().Name}: { truck.FuelQuantity:f2}");
        }
    }
}
