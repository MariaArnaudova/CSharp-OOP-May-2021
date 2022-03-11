using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        //private List<IPrivate> privates;
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; private set; }

        public void AddPrivate(IPrivate @private)
        {
            this.Privates.Add(@private);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: { FirstName } { LastName } Id: { Id } Salary: { Math.Round(Salary):F2}");
            sb.AppendLine($"Privates:");

            foreach (var @private in this.Privates)
            {
                sb.AppendLine($"  {@private}");
            }

            return sb
                .ToString()
                .TrimEnd();
           
        }
    }
}
