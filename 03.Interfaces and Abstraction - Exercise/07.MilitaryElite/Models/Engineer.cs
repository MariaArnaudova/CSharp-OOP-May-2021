using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<IRepair> repairs;
        public Engineer(string id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {

           this.repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; private  set; }

        public void AddRepair(IRepair repair)
        {
            repairs.Add(repair);
        }

        public override string ToString()
        {
                 StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Name: {FirstName} { LastName } Id: { Id } Salary: { Salary }");
            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine($"Repairs");
            sb.AppendLine($" {repairs}");
            return sb.ToString();
        }
    }
}
