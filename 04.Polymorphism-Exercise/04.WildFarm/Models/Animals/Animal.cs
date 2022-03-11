using System;
using System.Collections.Generic;
using System.Text;
using _04.WildFarm.Models.Foods;

namespace _04.WildFarm.Models.Animals
{
    public abstract class Animal
    {
        private int foodEaten;
        protected Animal(string name, double weight, int foodEaten)
        {
            Name = name;
            Weight = weight;
            FoodEaten = foodEaten;
        }

        public string Name { get; set; }
        public double Weight { get; set; }
        public int FoodEaten
        {
            get { return this.foodEaten; }
            set { foodEaten = value; }
        }

        public abstract void MakeSound();

        public virtual void Eat(string foodType, int quantity)
        {
            this.Weight += quantity;
        }

}
}
