using System;
using System.Collections.Generic;
using System.Text;

namespace BirthdayCelebrations
{
   public class Citizen:  IIdentifiable, IBirthdate
    {     
        public Citizen(string name, string id, int age, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
        public string Birthdate { get; set; }
        public string Name { get; private set; }
        public int  Age { get; private set; }
        public string Id { get; private set; }

    }
    
}
