using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Meat")
            {
                Console.WriteLine($"{ this.GetType().Name} does not eat { foodType}!");
                //this.FoodEaten -= base.FoodEaten;
                this.FoodEaten -= quantity;
            }
            else
            {
                this.Weight += 0.40*quantity;
                //base.Eat(foodType);
            }
        }
    }
}
