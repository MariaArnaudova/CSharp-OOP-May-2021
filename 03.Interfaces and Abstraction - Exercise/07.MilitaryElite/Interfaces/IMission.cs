using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public interface IMission
    {
        public string CodeName { get; }
        public string State { get; }

        public void CompleteMission();

    }
}
