using FightingArena;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class ArenaTests
    {
        Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
        }

        [Test]  // 53/100
        public void Constructor_ShouldCreateNewColection()
        {
            
            List<Warrior> expectedList = new List<Warrior>();
            IReadOnlyCollection<Warrior> actualList = this.arena.Warriors;
            Assert.That(expectedList, Is.EqualTo(actualList));
        }

        [Test]

        public void Counter_WhenEnrollCorectly_ShouldEncreaseCount()
        {
            Warrior warrior = new Warrior("Pesho", 20, 5);
            this.arena.Enroll(warrior);
            int expectedCount = 1;
            int actualCount = this.arena.Count;
            Assert.AreEqual(expectedCount, actualCount);
        }

        [Test]  // 66/100

        public void Enroll_ShouldThrowExceptionIfWarriorsContainsSameName()
        {
            Warrior warrior = new Warrior("Pesho", 20, 5);
            this.arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => this.arena.Enroll(warrior));
        }

        [Test] // 60/100

        public void Enroll_ShouldAddWarriorToColection()
        {
            Warrior warrior = new Warrior("Pesho", 20, 5);
            this.arena.Enroll(warrior);
            string expectedName = "Pesho";
            Warrior actualwarrior = arena.Warriors.FirstOrDefault(w => w.Name == expectedName);
            Assert.AreEqual(expectedName, actualwarrior.Name);
        }

    
        [Test] // 73/100 

        public void Fight_ShouldThrowException_IfAttacerNameIsNull()
        {
            string attackerName = "Pesho";
            Warrior defender = new Warrior("Staff", 20, 5);
            this.arena.Enroll(defender);
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attackerName, defender.Name));

        }


        [Test] // 73/100 

        public void Fight_ShouldThrowException_IfDefenderNameIsNull()
        {
            string defenderName = "Pesho";
            Warrior attacker = new Warrior("Pesho", 20, 5);
            this.arena.Enroll(attacker);
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attacker.Name, defenderName));

        }


        [Test] // 93/100

        public void Fight_ShouldThrowException_IfDefenderAndAttackerNamesAreNull()
        {
            string defenderName = "Pesho";
            string attackerName = "Staff";
            Assert.Throws<InvalidOperationException>(() => this.arena.Fight(attackerName, defenderName));
        }

        [Test]
        public void Fight_WarriorShouldAttack()
        {
            Warrior warrior = new Warrior("Pesho", 20, 35);
            this.arena.Enroll(warrior);
            Warrior warrior2 = new Warrior("Staff", 20, 32);
            this.arena.Enroll(warrior2);
            this.arena.Fight("Pesho", "Staff");
        }

             
    }
}
