using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Computers.Tests
{

    public class Tests
    {
        private ComputerManager compManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.compManager = new ComputerManager();
            this.computer = new Computer("Dell", "Inspirion", 2000m);
        }

    
        [Test]

        public void Ctor_Computer_ShouldInitializeProperties()
        {
            string manufacturer = "Dell";
            string model = "Inspirion";
            decimal price = 2000m;

            Assert.AreEqual(manufacturer, computer.Manufacturer);
            Assert.AreEqual(model, computer.Model);
            Assert.AreEqual(price, computer.Price);
        }


        [Test]

        public void Ctor_ShouldInitializeEmptyList()
        {
              int expectedCount = 0;
            Assert.AreEqual(expectedCount, compManager.Computers.Count);
        }


        [Test]
        public void Prop_ReturnsCollectionAsReadOnly()
        {
            Assert.IsInstanceOf<IReadOnlyCollection<Computer>>(this.compManager.Computers);
        }

        [Test]

        public void Ctor_ShouldInitializeColection()
        {
            IReadOnlyCollection<Computer> expectedColectionComputers = new List<Computer>();
            Assert.AreEqual(expectedColectionComputers, compManager.Computers);
        }

        [Test]

        public void ComputersProperty_ReturnIreadonlyColection()
        {
            this.compManager.AddComputer(new Computer("Dell", "Inspirion2", 2000m));
            this.compManager.AddComputer(new Computer("Dell", "Inspirion3", 2000m));
            this.compManager.AddComputer(new Computer("Dell", "Inspirion4", 2000m));
            IReadOnlyCollection<Computer> expectedColection = this.compManager.Computers;
            Assert.AreEqual(expectedColection, this.compManager.Computers);

        }

        [Test]
        public void AddComputer_ThrowExceptionIfComputerExist()
        {
            this.compManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => this.compManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_ShouldAddComputerCorrectly()
        {
            this.compManager.AddComputer(computer);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, compManager.Count);
        }

        [Test]

        public void AddComputer_ValidateNullValue_ShouldThrowExceptionIfObjectIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.compManager.AddComputer(null));
        }

        [Test]
        public void RemoveComputer_ShouldReturnComputerCorrectly()
        {
            this.compManager.AddComputer(computer);
            Computer expectedComp = compManager.RemoveComputer("Dell", "Inspirion");
            Assert.AreEqual(this.computer, expectedComp);
        }

        [Test]
        public void RemoveComputer_ShouldDecreaseListCount()
        {
            this.compManager.AddComputer(computer);
            Computer remoivedComp = compManager.RemoveComputer("Dell", "Inspirion");
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, this.compManager.Computers.Count);
        }

        [Test]
        public void RemoveComputer_ShouldThrowException_ValidateNullValue()
        {
            this.compManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => compManager.RemoveComputer(null, "Inspirion"));
        }

        [Test]
        public void RemoveComputer_ShouldThrowException_ValidateNullValueOfModel()
        {
            this.compManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => compManager.RemoveComputer("Dell", null));
        }

        [Test]
        public void RemoveComputer_ShouldThrowException_ValidateNullValueOfModelAndManufacturar()
        {
            this.compManager.AddComputer(computer);
            Assert.Throws<ArgumentNullException>(() => compManager.RemoveComputer(null, null));
        }

        [Test]
        public void GetComputer_ShouldReturnComputerCorrectly()
        {
            this.compManager.AddComputer(computer);
            Computer expectedComputer = this.computer;
            Assert.AreEqual(expectedComputer, this.compManager.GetComputer("Dell", "Inspirion"));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfComputerisNull()
        {
            Assert.Throws<ArgumentException>(() => this.compManager.GetComputer("Dell", "Inspirion22"));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.compManager.GetComputer(null, "Inspirion22"));
        }

        [Test]
        public void GetComputer_ShouldThrowExceptionIfModelIsNull() 
        {
            Assert.Throws<ArgumentNullException>(() => this.compManager.GetComputer("Dell", null));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnColection()
        {
            this.compManager.AddComputer(computer);
            this.compManager.AddComputer(new Computer("Dell", "Inspirion2", 2000m));
            this.compManager.AddComputer(new Computer("Dell", "Inspirion3", 2000m));
            this.compManager.AddComputer(new Computer("Dell", "Inspirion4", 2000m));
            ICollection<Computer> expectedColectionComputers = compManager.GetComputersByManufacturer("Dell");
            Assert.AreEqual(expectedColectionComputers, compManager.GetComputersByManufacturer("Dell"));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowException()
        {
            this.compManager.AddComputer(computer);
            this.compManager.AddComputer(new Computer("Dell", "Inspirion2", 2000m));
            this.compManager.AddComputer(new Computer("Dell", "Inspirion3", 2000m));
            this.compManager.AddComputer(new Computer("Dell", "Inspirion4", 2000m));
            Assert.Throws<ArgumentNullException>(() => compManager.GetComputersByManufacturer(null));
        }

    }
}