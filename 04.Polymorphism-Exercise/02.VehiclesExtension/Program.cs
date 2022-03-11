using System;
using System.Collections.Generic;

namespace Vehicles
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] carData = Console.ReadLine().Split();

            double carFuelQuantity = double.Parse(carData[1]);
            double carFuelConsumption = double.Parse(carData[2]);
            double tankCapacity = double.Parse(carData[3]);

            Vehicle car = new Car(carFuelQuantity, carFuelConsumption, tankCapacity);

            string[] truckData = Console.ReadLine().Split();
            double fuelQuantity = double.Parse(truckData[1]);
            double fuelConsumption = double.Parse(truckData[2]);
            double truckTankCapacity = double.Parse(truckData[3]);


            Vehicle truck = new Truck(fuelQuantity, fuelConsumption, truckTankCapacity);

            string[] busData = Console.ReadLine().Split();
            double busFuelQuantity = double.Parse(busData[1]);
            double busFuelConsumption = double.Parse(busData[2]);
            double busTankCapacity = double.Parse(busData[3]);

            Bus bus = new Bus(busFuelQuantity, busFuelConsumption, busTankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string command = tokens[0];
                string vehicle = tokens[1];
                double distance = double.Parse(tokens[2]);
                if (command == "Drive")
                {

                    if (vehicle == "Car")
                    {
                        car.Drive(distance);
                    }
                    else if (vehicle == "Truck")
                    {
                        truck.Drive(distance);
                    }
                    else if (vehicle == "Bus")
                    {
                        bus.IsEmpty = false;
                        bus.Drive(distance);
                    }
                }
                else if (command == "DriveEmpty")
                {
                    
                    bus.IsEmpty = true;
                    bus.Drive(distance);
                }
                else if (command == "Refuel")
                {
                    double liters = distance;

                    try
                    {
                        if (vehicle == "Car")
                        {
                            car.Refuel(liters);
                        }
                        else if (vehicle == "Truck")
                        {
                            truck.Refuel(liters);
                        }
                        else if (vehicle == "Bus")
                        {
                            bus.Refuel(liters);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }

            Console.WriteLine($"{car.GetType().Name}: { car.FuelQuantity:f2}");
            Console.WriteLine($"{truck.GetType().Name}: { truck.FuelQuantity:f2}");
            Console.WriteLine($"{bus.GetType().Name}: { bus.FuelQuantity:f2}");
        }
    }
}
