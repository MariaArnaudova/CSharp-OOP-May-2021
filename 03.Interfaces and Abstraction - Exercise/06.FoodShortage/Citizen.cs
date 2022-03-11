using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
    public class Citizen : IIdentifiable, IBirthdate, IBuyer
    {    
        public Citizen(string name, int age, string id, string birthdate, int food)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
            Food = food;
        }
        public string Birthdate { get; set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Id { get; private set; }
        public int  Food { get; set; }
     
        public void BuyFood()
        {
            this.Food += 10;
        }
    }

}
