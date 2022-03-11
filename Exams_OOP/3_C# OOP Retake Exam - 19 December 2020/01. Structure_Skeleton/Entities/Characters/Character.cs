using System;

using WarCroft.Constants;
using WarCroft.Entities.Inventory;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Characters.Contracts
{
    public abstract class Character
    {
        private string name;
        private double health;
        private double armor;
        // TODO: Implement the rest of the class.

        protected Character(string name, double health, double armor, double abilityPoints, Bag bag)
        {
            this.Name = name;
            this.BaseHealth = health;
            this.Health = health;
            this.BaseArmor = armor;
            this.Armor = armor;
            this.AbilityPoints = abilityPoints;
            this.Bag = bag;
        }

        public double AbilityPoints { get; private set; }
        public double BaseArmor { get; }
        public double BaseHealth { get; }
        public Bag Bag { get; private set; }
        public bool IsAlive { get; set; } = true;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.CharacterNameInvalid);
                }

                name = value;
            }
        }

        public double Health
        {
            get
            {
                return this.health;
            }
            set
            {
                if (value < 0)
                {
                    this.health = 0;
                }
                else if (value > BaseHealth)
                {
                    this.health = this.BaseHealth;
                }
                else
                {
                    this.health = value;
                }
            }
        }

        public double Armor
        {
            get
            {
                return this.armor;
            }
            set
            {
                if (value < 0)
                {
                    this.armor = 0;
                }
                else
                {
                    this.armor = value;
                }
            }
        }

        protected void EnsureAlive()
        {
            if (!this.IsAlive)
            {
                throw new InvalidOperationException(ExceptionMessages.AffectedCharacterDead);
            }
        }

        public virtual void TakeDamage(double hitPoints)
        {
            this.EnsureAlive();
            double lessPoints = hitPoints - this.Armor;
            this.Armor -= hitPoints;

            if (this.Armor <= 0)
            {
                this.Armor = 0;
            }

            if (lessPoints > 0)
            {
                this.health -= lessPoints;
            }

            if (this.health <= 0)
            {
                this.Health = 0;
                this.IsAlive = false;
            }
        }
        public virtual void UseItem(Item item)
        {
            this.EnsureAlive();

            item.AffectCharacter(this);
        }
    }
}
