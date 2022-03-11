using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class Soldier: ISoldier
    {
        public Soldier(string id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
           return $"Name: {FirstName} {LastName} Id: {Id}";
        }
    }
}
