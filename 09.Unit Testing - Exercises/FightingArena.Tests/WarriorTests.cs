using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {

            this.warrior = new Warrior("Pesho", 20, 31);
        }

        [Test]
        [TestCase("", 20, 5)]
        [TestCase(" ", 20, 5)]
        [TestCase(null, 20, 5)]
        [TestCase("Pesho", 0, 5)]
        [TestCase("Pesho", -3, 5)]
        [TestCase("Pesho", 20, -4)]

        public void Constructor_ShouldThrowExceptinIfParametersAreNotValid(string name, int damage, int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, damage, hp));
        }

        [Test]

        public void Constructor_ShouldSetValidParameters()
        {
            string name = "Pesho";
            int damage = 20;
            int hp = 5;

            Warrior warrior = new Warrior(name, damage, hp);

            Assert.That(name, Is.EqualTo(warrior.Name));
            Assert.That(damage, Is.EqualTo(warrior.Damage));
            Assert.That(hp, Is.EqualTo(warrior.HP));
        }


        [Test]

        public void Attack_ShouldThrowExceptionYourHPUderMIN_ATTACK_HP()
        {
            this.warrior = new Warrior("Pesho", 20, 29);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(this.warrior));
        }

        [Test]
        [TestCase("Karo", 10, 28)] //86/100
        [TestCase("Karo", 10, 30)]
        public void Attack_ShouldThrowExceptionIfDefenderAttackerHPIsUderMIN_ATTACK_HP(string name, int damage, int hp)
        {
            Warrior defender = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(defender));
        }

        [Test]
        [TestCase("Karo", 10, 28)] // 86/100
        [TestCase("Karo", 10, 30)]  
        public void Attack_ShouldThrowExceptionIfAttackerHPIsUderMIN_ATTACK_HP(string name, int damage, int hp)
        {
            Warrior defender = new Warrior("Pesho", 20, 32);
            this.warrior = new Warrior(name, damage, hp);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(defender));
        }

        [Test] //86/100

        public void Attack_ShouldThrowExceptionAtakerIsLessOfDefender()
        {
            Warrior newWarrior = new Warrior("Staff", 34, 32);
            Assert.Throws<InvalidOperationException>(() => this.warrior.Attack(newWarrior));
        }

        [Test]

        public void Attack_ShouldSetDefenderHPToZero()
        {
            this.warrior = new Warrior("Pesho", 33,35);
            Warrior newWarrior = new Warrior("Staff", 10, 32);
            this.warrior.Attack(newWarrior);
            int expectedWarrioHp = 0;
            Assert.That(expectedWarrioHp, Is.EqualTo(newWarrior.HP));
        }

        [Test]

        public void Attack_ShouldDecreaseDefenderHP()
        {
            this.warrior = new Warrior("Pesho", 10, 35);
            Warrior newWarrior = new Warrior("Staff", 33, 32);
            this.warrior.Attack(newWarrior);
            int expectedWarrioHp = 22;
            Assert.That(expectedWarrioHp, Is.EqualTo(newWarrior.HP));
        }


        [Test]

        public void Attack_ShouldDecreaseAttackerHP()
        {
            this.warrior = new Warrior("Pesho", 10, 35);
            Warrior newWarrior = new Warrior("Staff", 33, 32);
            this.warrior.Attack(newWarrior);
            int expectedMyHp = 2;
            Assert.That(expectedMyHp, Is.EqualTo(this.warrior.HP));
        }
    }
}