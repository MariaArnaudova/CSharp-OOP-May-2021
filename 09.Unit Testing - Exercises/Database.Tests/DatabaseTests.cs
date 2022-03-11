using NUnit.Framework;
using System;

namespace Tests
{
    using Database;

    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Constructor_ShouldBe_InitializedWith16Ellements()
        {
            int[] array = new int[16];

            Database dataBase = new Database(array);

            int expectedCount = 16;
            int actualCount = dataBase.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Constructor_ShouldBe_TrowInvalidOperationExceptiondIsOver16Elements(int[] array)
        {
            array = new int[16];

            Database dataBase = new Database(array);
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(1));
        }

        [Test]
        public void AddMethod_ShouldIncreaseTheCount()
        {
            Database dataBase = new Database();

            dataBase.Add(1);
            int expectedCount = 1;
            int actualCount = dataBase.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]
        public void AddMethod_ShouldAddElementCorrectlyOnTheNetxtEmptyIndex()
        {
            Database dataBase = new Database();

            dataBase.Add(1);
            int expectedCount = 1;
            int actualCount = dataBase.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void AddMethod_ShouldBe_TrowInvalidOperationExceptiondIsOver16Elements(int[] array)
        {
            array = new int[16];

            Database dataBase = new Database(array);
            Assert.Throws<InvalidOperationException>(() => dataBase.Add(1));
        }

   
        [Test]
        public void Remove_ShouldRemovingLastElementFromDb()
        {
            int[] array = { 1, 2, 3 };
            Database dataBase = new Database(array);
            dataBase.Remove();
            int expectedCount = 2;
            int actualValue = dataBase.Fetch()[dataBase.Count-1];
            Assert.AreEqual(expectedCount, actualValue);
        }

        [Test]
        public void Remove_ShouldTrowInvalidOperationExceptiond_WhenRemoveElementFromEmptyDatabase()
        {
            Database dataBase = new Database();

            Assert.Throws<InvalidOperationException>(() => dataBase.Remove());
        }

    
        [Test]
        public void Fetch_ShouldReturdDbWithCopy()
        {
            int[] array = { 1, 2, 3 };
            Database dataBase = new Database(array);       
            int[] copyBase = dataBase.Fetch();
            Assert.AreEqual(array, copyBase);
        }
    }
}