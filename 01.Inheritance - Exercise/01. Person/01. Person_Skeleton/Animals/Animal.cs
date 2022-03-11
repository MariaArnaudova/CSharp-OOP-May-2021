using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public abstract class Animal
    {
        public string name;
        public int age;
        public string gender;

        public Animal(string name, int age, string gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            protected set
            {
                if ( string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Invalid input!");
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
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.age = value;
            }
        }
        public string Gender
        {
            get
            {
                return this.gender;
            }
            protected
            set
            {
                if ((value != "Male" && value != "Female"))
                {
                    throw new ArgumentException("Invalid input!");
                }
                this.gender = value;
            }

        }

        public abstract string ProduceSound();

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.GetType().Name}");
            sb.AppendLine($"{Name} {Age} {Gender}");
            sb.Append(this.ProduceSound());
            return sb.ToString();
        }
    }
}
