using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
   public class Private :Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return $"Name: { FirstName } { LastName } Id: { Id } Salary: {Salary:F2}";
        }
    }
}
