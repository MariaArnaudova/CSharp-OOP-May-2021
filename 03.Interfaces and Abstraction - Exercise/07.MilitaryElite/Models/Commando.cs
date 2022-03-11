using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<IMission> missions;
        public Commando(string id, string firstName, string lastName, decimal salary, string corp)
            : base(id, firstName, lastName, salary, corp)
        {
            missions = new List<IMission>();

        }
        public List<IMission> Missions { get; private set; }

        public void AddMission(IMission mission)
        {
            missions.Add(mission);
        }

        public override string ToString()
        {

                StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {FirstName} {LastName} Id: {Id} Salary: {Salary}");
            sb.AppendLine($"Corps: {Corp}");
            sb.AppendLine($"Missions:");
            sb.AppendLine($" {missions}");
            return sb.ToString().Trim();
        }
    }
}
