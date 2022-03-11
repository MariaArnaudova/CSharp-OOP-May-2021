using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Druid : BaseHero
    {
        private const int powerConst = 80;
        public Druid(string name)
            : base(name, powerConst)
        {

        }
        public override int Power => powerConst;
        public override string CastAbility()
        {
            return $"{ this.GetType().Name} - {this.Name} healed for {this.Power }";
        }
    }
}
