using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Raiding
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raidGroup = new List<BaseHero>();

            while (raidGroup.Count != n)
            {

                string name = Console.ReadLine();
                string type = Console.ReadLine();

                if (type == "Druid")
                {
                    BaseHero hero = new Druid(name);
                    raidGroup.Add(hero);

                }
                else if (type == "Paladin")
                {
                    BaseHero hero = new Paladin(name);
                    raidGroup.Add(hero);
                }
                else if (type == "Rogue")
                {
                    BaseHero hero = new Rogue(name);
                    raidGroup.Add(hero);
                }
                else if (type == "Warrior")
                {
                    BaseHero hero = new Warrior(name);
                    raidGroup.Add(hero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            int sumPowers = raidGroup.Select(x => x.Power).Sum();

            foreach (var heroe in raidGroup)
            {
                Console.WriteLine(heroe.CastAbility());
            }

            if (sumPowers >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

            //Console.WriteLine(sumPowers >= bossPower? "Victory!": "Defeat...");

        }

    }
}
