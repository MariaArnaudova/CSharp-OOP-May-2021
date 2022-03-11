using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Rogue : BaseHero
    {

        private const int powerConst = 80;
        public Rogue(string name) 
            : base(name, powerConst)
        {
        }

        public override int Power => powerConst;
        public override string CastAbility()
        {
            return $"{ this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
