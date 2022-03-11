﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FoodShortage
{
  public  class Rebel:IBuyer
    {
        public Rebel(string name, int age, string group, int food)
        {
            this.Name = name;
            Age = age;
            Group = group;
            Food = food;
        }
        public string Name  { get; set; }
        public int Age  { get; set; }
        public string Group { get; set; }
        public int Food { get; set; }

        public void BuyFood()
        {
            this.Food += 5;
        }
    }
}
