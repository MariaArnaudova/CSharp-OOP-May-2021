using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        private Car car;

        [SetUp]
        public void Setup()
        {
            car = new Car("Fiat", "Abart", 5, 50);
        }

        [Test]
        [TestCase(null, "Abart", 5, 50)]
        [TestCase("", "Abart", 5, 50)]
        [TestCase("Fiat", null, 5, 50)]
        [TestCase("Fiat", "", 5, 50)]
        [TestCase("Fiat", "Abart", 0, 50)]
        [TestCase("Fiat", "Abart", -12, 50)]
        [TestCase("Fiat", "Abart", 5, 0)]
        [TestCase("Fiat", "Abart", 5, -14)]
        public void Constructor_ShouldTrowExceptionIfSetInvalidParametrs(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]

        public void Constructor_SetValidParameters()
        {
            string make = "Fiat";
            string model = "Abart";
            double fuelConsumption = 5;
            double fuelCapacity = 50;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.That(make, Is.EqualTo(car.Make));             
            Assert.That(model, Is.EqualTo(car.Model));             
            Assert.That(fuelConsumption, Is.EqualTo(car.FuelConsumption));             
            Assert.That(fuelCapacity, Is.EqualTo(car.FuelCapacity));             
        }

        [Test]
        public void Refuel_ShouldEncreaseFuelAmount()
        {
            this.car.Refuel(50);
            this.car.Drive(200);
            car.Refuel(5);
            double expectedFuelAmount = 45;
            double actualFuelAmount = car.FuelAmount;
            Assert.That(expectedFuelAmount, Is.EqualTo(actualFuelAmount));
        }

        [Test]
        public void Refuel_ShouldThrowExceptionIfFuelToRefuelIsNegative()
        {
            
            this.car.Refuel(50);
            this.car.Drive(200);
            Assert.Throws<ArgumentException>(() => car.Refuel(-5));
        }

        [Test]
        public void Refuel_ShouldSetFuelAmountEqualToFuelCapacity()
        {           
            this.car.Refuel(50);
            this.car.Drive(200);
            car.Refuel(15);
            double expectedFuelAmount = 50;
            double actualFuelAmount = car.FuelAmount;
            Assert.That(expectedFuelAmount, Is.EqualTo(actualFuelAmount));
        }

        [Test]

        public void Drive_ShouldThrowExceptionIfFuelNeededIsMoreOfFuelAmount()
        {
            this.car.Refuel(5);          
            Assert.Throws<InvalidOperationException>(() => this.car.Drive(110));
        }

        [Test]

        public void Drive_ShouldTDecreaseFuelAmount()
        {
            this.car.Refuel(50);
            this.car.Drive(200);
            double expectedFuelAmount = 40;
            double actualFuelAmount = car.FuelAmount;
            Assert.That(expectedFuelAmount, Is.EqualTo(actualFuelAmount));
        }
    }
}