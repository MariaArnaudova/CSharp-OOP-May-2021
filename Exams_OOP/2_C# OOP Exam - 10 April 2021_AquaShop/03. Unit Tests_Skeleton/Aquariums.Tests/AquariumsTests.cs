namespace Aquariums.Tests
{
    using NUnit.Framework;
    using System;


    [TestFixture]
    public class AquariumsTests
    {

        private Aquarium aquarium;
        private Fish fish;

        [SetUp]

        public void SetUp()
        {
            this.aquarium = new Aquarium("Ocean", 20);
            this.fish = new Fish("Nemo");
        }


        [Test]
        [TestCase("", 20)]
        [TestCase(null, 20)]
        public void Name_ShouldThrowExceptionToInavlidName(string name, int capacity)
        {

            Assert.Throws<ArgumentNullException>(() => this.aquarium = new Aquarium(name, capacity));
        }


        [Test]

        public void Name_ShouldThrowSetValidName()
        {

            string expectedName = "Ocean";

            Assert.AreEqual(expectedName, this.aquarium.Name);
        }

        [Test]

        public void Capacity_ShouldThrowExceptionIfLessToZerro()
        {

            Assert.Throws<ArgumentException>(() => this.aquarium = new Aquarium("Ocean", -1));
        }

        [Test]

        public void Capacity_ShouldSetValidCapacity()
        {

            int expectedCapacity = 20;

            Assert.AreEqual(expectedCapacity, this.aquarium.Capacity);
        }


        [Test]

        public void Add_ShouldThrowExceptionIfFishCountIsEqualToCapacity()
        {

            this.aquarium = new Aquarium("Ocean", 2);
            aquarium.Add(fish);
            aquarium.Add(fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(fish));
        }


        [Test]

        public void Add_ShouldAddFishToAquarium()
        {
            aquarium.Add(fish);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.aquarium.Count);
        }


        [Test]

        public void Remove_ShouldThrowException_IfFishIsNull()
        {
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.RemoveFish("Gupa"));
        }

        [Test]

        public void Remove_ShouldRemoveValidFish()
        {
            aquarium.Add(fish);
            this.aquarium.RemoveFish("Nemo");
            int expectedCount = 0;
            Assert.AreEqual(expectedCount, this.aquarium.Count);
        }

        [Test]

        public void SellFish_ShouldThrowException_IfFishIsNull()
        {
            this.aquarium.Add(this.fish);
            Assert.Throws<InvalidOperationException>(() => aquarium.SellFish("Gupa"));
        }

        [Test]

        public void SellFish_ShouldSellFish_IfFishNameIsValid()
        {
            aquarium.Add(fish);
            string expectedfish = "Nemo";
            Assert.AreEqual(expectedfish, this.aquarium.SellFish("Nemo").Name);
        }

        [Test]

        public void Report_ShouldReturnRportToAquarium()
        {
            aquarium.Add(fish);

            string fishNames = string.Join(", ", this.fish.Name);
            string expectedReport = $"Fish available at {this.aquarium.Name}: {fishNames}";

            Assert.AreEqual(expectedReport, aquarium.Report());
        }


    }


}
