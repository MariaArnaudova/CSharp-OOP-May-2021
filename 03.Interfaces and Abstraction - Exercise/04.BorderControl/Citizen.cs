using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
   public class Citizen:  IIdentifiable
    {
      
        public Citizen(string name, string id, int age)
        {
            Name = name;
            Age = age;
            Id = id;
        }

        public string Name { get; private set; }
        public int  Age { get; private set; }
        public string Id { get; private set; }
    }
    
}
