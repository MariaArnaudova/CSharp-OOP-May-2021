using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, int foodEaten, string livingRegion, string breed) 
            : base(name, weight, foodEaten, livingRegion, breed)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Meow");
        }

        public override void Eat(string foodType, int quantity)
        {
            if (foodType!="Vegetable" && foodType != "Meat")
            {
                Console.WriteLine($"{ this.GetType().Name} does not eat { foodType}!");
                this.FoodEaten -= quantity;
            }
            else
            {
                this.Weight += 0.30* quantity;
                //base.Eat(foodType);
            }           
        }
    }
    
}
