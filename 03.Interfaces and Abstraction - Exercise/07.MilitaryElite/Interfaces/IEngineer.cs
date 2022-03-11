using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Interfaces
{
    public interface IEngineer: ISpecialisedSoldier
    {
        public List<IRepair> Repairs { get;}
        public void AddRepair(IRepair repair);
    }
}
