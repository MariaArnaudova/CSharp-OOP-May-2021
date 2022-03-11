using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, int foodEaten, double wingSize)
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                Console.WriteLine($"{ this.GetType().Name} does not eat { foodType}!");
                this.FoodEaten -= quantity;
            }
            else
            {
                this.Weight += 0.25 * quantity;
                //base.Eat(foodType);
            }
        }
    }
}
