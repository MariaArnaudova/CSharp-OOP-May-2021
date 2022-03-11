using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalFarm
{
    public class Chicken
    {
       private const int MinAge = 0;
       private const int MaxAge = 15;

        private string name;
        private int age;
        //private int productPerDay;

        public Chicken(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public int ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }
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
                    throw new ArgumentException($"Name cannot be empty.");
                }
                this.name = value;
            }
        }
         
        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value <= MinAge || value >= MaxAge)
                {
                    throw new ArgumentException($"Age should be between 0 and 15.");
                }
                this.age = value;
            }
        }

        private int CalculateProductPerDay()
        {
            //if (age > MinAge && age <= MaxAge)
            //{
            //    productPerDay = 1;
            //}
            //else
            //{
            //    throw new ArgumentException($"Age should be between 0 and 15.");
            //}
            return 1;
        }
    }
}
