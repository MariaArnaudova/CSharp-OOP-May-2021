using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Mission: IMission
    {
        public Mission(string codeName, State state)
        {
            CodeName = codeName;
            State = state;
        }

        public string CodeName { get; set; }
        public State State { get; private set; }

        string IMission.State => throw new NotImplementedException();

        public void CompleteMission()
        {
            State = State.Finshed;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Code Name: {CodeName} State: {State}");
            return sb.ToString();
        }
    }
}
