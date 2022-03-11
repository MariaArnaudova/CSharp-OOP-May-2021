using System;
using System.Collections.Generic;
using System.Text;

namespace _04.WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, int foodEaten, double wingSize) 
            : base(name, weight, foodEaten, wingSize)
        {
        }

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }

        public override void Eat(string foodType, int quantity)
        {
            this.Weight += 0.35* quantity;
            //base.Eat(foodType);
        }
    }
}
