using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
  public  class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{FirstName} {LastName} is {Age} years old.");
            return sb.ToString().TrimEnd();
        }
    }
}
