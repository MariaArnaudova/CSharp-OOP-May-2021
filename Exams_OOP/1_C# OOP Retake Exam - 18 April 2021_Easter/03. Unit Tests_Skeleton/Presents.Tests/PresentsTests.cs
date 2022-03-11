namespace Presents.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;
        private Present present;

        [SetUp]

        public void SetUp()
        {
            this.bag = new Bag();
            this.present = new Present("Presure", 14.0);
        }

        [Test]

        public void Create_ShouldThrowExceptoinIfPresentIsNull()
        {
            present = null;
            Assert.Throws<ArgumentNullException>(() => bag.Create(present));
        }

        [Test]

        public void Create_ShouldThrowExceptoinIfPresentIsExists()
        {
            bag.Create(present);
            Assert.Throws<InvalidOperationException>(() => bag.Create(present));
        }

        [Test]
        public void Create_ShouldAddPresentCorectly()
        {
            bag.Create(present);
            Present expestedPresent = present;
            Assert.AreEqual(expestedPresent, bag.GetPresent(present.Name));
        }

        [Test]
        public void Create_ShouldReturnSucsessMessage()
        {
            string expectedMessage = $"Successfully added present { present.Name}.";
            Assert.AreEqual(expectedMessage, bag.Create(present));
        }

        // do tuk 71/100
        [Test]

        public void Remove_ShouldReturnBoolIfRemovePresent()
        {
            bag.Create(present);            
            bool expektedBoll = true;
            Assert.AreEqual(expektedBoll, bag.Remove(present));
        }

        [Test]
        public void GetPresentWithLeastMagic_Should_ReturnPresentWithLeastMagic()
        {
            Present newPresent = new Present("Surprise", 8.00);
            bag.Create(present);
            bag.Create(newPresent);

            Present expectedPresent = newPresent;

            Assert.AreEqual(expectedPresent, bag.GetPresentWithLeastMagic());
        }

        [Test]

        public void GetPresent_ShouldReturnPresent()
        {
            bag.Create(present);
            Present expectedPresent = present;

            Assert.AreEqual(expectedPresent, bag.GetPresent(present.Name));
        }

        [Test]
        public void GetPresents_ShouldReturnCollectionOfPresenst()
        {
            //Present newPresent = new Present("Surprise", 8.00);
            //bag.Create(present);
            //bag.Create(newPresent);

            IReadOnlyCollection<Present> expectedColection = new List<Present>();

            Assert.AreEqual(expectedColection, bag.GetPresents());
        }
    }
}
