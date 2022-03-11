using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Raiding
{
    public class Warrior : BaseHero
    {

        private const int powerConst = 100;
        public Warrior(string name)
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
