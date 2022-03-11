using NUnit.Framework;

namespace Tests
{
   using ExtendedDatabase;
    using System;

    public class ExtendedDatabaseTests
    {

        private ExtendedDatabase extendedDatabase;

        [SetUp]
        public void Setup()
        {
            this.extendedDatabase = new ExtendedDatabase();
        }

    
        [Test]
        public void Constructor_AddPersonsDataCorectly()
        {
            Person personOne = new Person(10, "FirstPerson");
            Person personTwo = new Person(12, "SecondPerson");
            this.extendedDatabase = new ExtendedDatabase(personOne, personTwo);

            int expectedCount = 2;
            int actualCount = this.extendedDatabase.Count;
            Assert.AreEqual(expectedCount, actualCount);

        }

        [Test]
        public void Constructor_Should_SetsCount()
        {
            Person[] persons = new Person[4];

            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "UserName" + i);
            }

            this.extendedDatabase = new ExtendedDatabase(persons);

            Assert.AreEqual(persons.Length, extendedDatabase.Count);
        }

        [Test]
        public void Constructor_Should_ThrowException_WhenDataIsIsExceeded()
        {
            Person[] persons = new Person[17];
        
            Assert.Throws<ArgumentException>(() => new ExtendedDatabase(persons));
        }

        [Test]
        public void Add_ShouldIncreaseTheCount()
        {
            this.extendedDatabase.Add(new Person(10, "NewPerson"));
            int expectedCount = 1;
            int actualCount = this.extendedDatabase.Count;
            Assert.That(expectedCount, Is.EqualTo(actualCount));
        }

        [Test]

        public void Add_Should_ThrowExceptionIfAddPersonOverCapacity()
        {
            Person[] persons = new Person[16];
            for (int i = 0; i < persons.Length; i++)
            {
                persons[i] = new Person(i, "UserName" + i);
            }
            this.extendedDatabase = new ExtendedDatabase(persons);
            Person lastPerson = new Person(10, "LastPerson");

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(lastPerson));
        }


        [Test]

        public void Add_Should_AddPersonAtRange()
        {

            Person currentPerson = new Person(12, "CurrentPerson");
            this.extendedDatabase.Add(currentPerson);
            int expectedCount = 1;
            int actualCount = this.extendedDatabase.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }


        [Test]

        public void Add_Should_ThrowExeptionWhenAddPersonWhithSameName()
        {
         
            this.extendedDatabase.Add(new Person(10, "NewPerson"));
            Person currentPerson = new Person(12, "NewPerson");

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Add(currentPerson));
        }

        [Test]

        public void Add_Should_ThrowExeptionWhenAddPersonWhithSameId()
        {
            this.extendedDatabase.Add(new Person(10, "NewPerson"));
            Person currentPerson = new Person(10, "CurrentPerson");

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(currentPerson));
        }

        [Test]

        public void Should_Remove_Person()
        {
            Person newPerson = new Person(10, "NewPerson");
            this.extendedDatabase = new ExtendedDatabase(newPerson);
            extendedDatabase.Remove();

            int expectedCount = 0;
            int actualCount = this.extendedDatabase.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]
        public void Remove_Should_ThrowExeption_WhenCountIsZero()
        {

            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.Remove());
        }


        [Test]

        public void Remove_Should_DecreaseCounter()
        {

            int n = 4;
            for (int i = 0; i < n; i++)
            {
                this.extendedDatabase.Add(new Person(i, $"UserName {i}"));
            }

            this.extendedDatabase.Remove();
            int expectedCount = n - 1;
            Assert.That(expectedCount, Is.EqualTo(this.extendedDatabase.Count));
        }

        [Test]

        public void Should_FindPersonByName()
        {
            Person newPerson = new Person(10, "NewPerson");
            this.extendedDatabase = new ExtendedDatabase(newPerson);
            Person foundPerson = this.extendedDatabase.FindByUsername(newPerson.UserName);
            //Person foundPerson = this.extendedDatabase.FindById(newPerson.Id);
            Assert.AreEqual(foundPerson, newPerson);
        }


        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void FindPersonByName_Should_ThrowExeption_IfUsernameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentNullException>(() => this.extendedDatabase.FindByUsername(name));
        }


        [Test]

        public void FindPersonByName_Should_ThrowExeption_IfNoUserIsPresentByThisUsername()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindByUsername("CurrentPerson"));
        }


        [Test]

        public void Should_FindPersonById()
        {
            Person newPerson = new Person(10, "NewPerson");
            this.extendedDatabase = new ExtendedDatabase(newPerson);
            Person foundPerson = this.extendedDatabase.FindById(newPerson.Id);
            Assert.AreEqual(newPerson, foundPerson);
        }

        [Test]

        public void Should_ThrowExeption_IfNoUserIsPresentByThisId()
        {
            Assert.Throws<InvalidOperationException>(() => this.extendedDatabase.FindById(12));
        }


        [Test]

        public void Should_ThrowExeption_IfPersonIdIsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => this.extendedDatabase.FindById(-12));
        }

    }
}