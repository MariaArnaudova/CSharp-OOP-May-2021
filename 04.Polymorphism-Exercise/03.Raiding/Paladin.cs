using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Paladin : BaseHero
    {
        private const int powerConst = 100;
        public Paladin(string name) 
            : base(name, powerConst)
        {

        }

        public override int Power =>  powerConst;
        public override string CastAbility()
        {
            return $"{ this.GetType().Name} - {this.Name} healed for {this.Power }";
        }
    }
}
