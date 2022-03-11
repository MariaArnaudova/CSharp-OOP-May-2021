using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        public SpecialisedSoldier(string id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary)
        {

            Corp = corp;
        }
        public string Corp { get; set; }
   
    }
}
