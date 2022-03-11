using _07.MilitaryElite.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _07.MilitaryElite.Models
{
    public class Repair: IRepair
    {
        public Repair(string partName, int hours)
        {
            PartName = partName;
            HoursWorked = hours;
        }

        public string PartName { get; private set; }
        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            return $"Part Name: {PartName} Hours Worked: {HoursWorked}";
        }
    }
}
