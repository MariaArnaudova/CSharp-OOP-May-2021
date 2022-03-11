using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private RaceEntry race;
        private UnitDriver driver;
        private UnitCar car;

        [SetUp]
        public void Setup()
        {
            this.race = new RaceEntry();
            this.car = new UnitCar("Brich", 100, 50.0);
            this.driver = new UnitDriver("Koko", car);

        }

        [Test]
        public void AddDriver_ShouldThrowExceptionIfDriverIsNull()
        {
            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(null));
        }

        [Test]

        public void AddDriver_ShouldThrowExceptionIfDriverExist()
        {
            this.race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => this.race.AddDriver(driver));
        }

        [Test]

        public void AddDriver_ShouldAddDriver()
        {
            this.race.AddDriver(driver);
            int expectedCount = 1;

            Assert.That(expectedCount, Is.EqualTo(race.Counter));
        }


        [Test]

        public void AddDriver_ShouldReturnStringIfAddDriver()
        {

            string expectedMessage = string.Format("Driver {0} added in race.", this.driver.Name);

            Assert.That(expectedMessage, Is.EqualTo(this.race.AddDriver(this.driver)));
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldThrowException()
        {
            this.race.AddDriver(driver);
            string expectedMessage = string.Format("The race cannot start with less than {0} participants.", 2);
            Assert.Throws<InvalidOperationException>(() => this.race.CalculateAverageHorsePower());
        }

        [Test]
        public void CalculateAverageHorsePower_ShouldCalulateCorrectly()
        {
            this.race.AddDriver(driver);

            this.car = new UnitCar("Brich", 140, 50.0);
            this.race.AddDriver(new UnitDriver("Pesho", car));

            double expectedAverageHorsePower = 120;
            Assert.AreEqual(expectedAverageHorsePower, this.race.CalculateAverageHorsePower());
        }
    }
}