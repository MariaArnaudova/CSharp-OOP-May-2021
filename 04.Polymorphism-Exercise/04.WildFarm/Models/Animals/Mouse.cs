using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, int foodEaten, string livingRegion)
            : base(name, weight, foodEaten, livingRegion)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType != "Vegetable" && foodType != "Fruit")
            {
                Console.WriteLine($"{ this.GetType().Name} does not eat { foodType}!");
                this.FoodEaten -= quantity;
            }
            else
            {
                this.Weight += 0.10* quantity;
                //base.Eat(foodType);
            }
        }
    }
}
