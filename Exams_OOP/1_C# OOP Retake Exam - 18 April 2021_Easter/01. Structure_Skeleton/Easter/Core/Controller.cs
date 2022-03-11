using Easter.Core.Contracts;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Models.Workshops.Contracts;
using Easter.Repositories;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Core
{
    public class Controller : IController
    {

        private BunnyRepository bunnies;
        private EggRepository eggs;

        public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }

        public string AddBunny(string bunnyType, string bunnyName)
        {
            if (bunnyType == "HappyBunny")
            {
                this.bunnies.Add(new HappyBunny(bunnyName));
            }
            else if (bunnyType == "SleepyBunny")
            {
                this.bunnies.Add(new SleepyBunny(bunnyName));
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }

            return $"Successfully added {bunnyType} named {bunnyName}.";
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            Dye dye = new Dye(power);
            IBunny bunny = bunnies.FindByName(bunnyName);
            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyName);
            }
            bunny.AddDye(dye);

            return $"Successfully added dye with power {dye.Power} to bunny {bunnyName}!";
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            Egg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return $"Successfully added egg: {eggName}!";
        }

        public string ColorEgg(string eggName)
        {
            IWorkshop workshop = new Workshop();
            IEgg egg = eggs.FindByName(eggName);
            List<IBunny> bunniesPainters = bunnies.Models.Where(x => x.Energy >= 50)
                                          .OrderByDescending(x => x.Energy).ToList();

            if (bunniesPainters.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }

            IBunny bunny = bunniesPainters.First();

            while (bunny.Energy > 0)
            {

                bunny = bunniesPainters.First();

                if (bunny.Energy == 0 || bunny.Dyes.All(x => x.IsFinished()))
                {
                    bunniesPainters.Remove(bunny);

                    if (bunniesPainters.Count == 0)
                    {
                        break;
                    }
                    continue; 
                }

                workshop.Color(egg, bunny);

                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    //return $"Egg {eggName} is done.";
                    break;
                }
            }

            if (egg.IsDone())
            {
                return $"Egg {eggName} is done.";
            }
            else
            {
                return $"Egg {eggName} is not done.";
            }           
        }

        public string Report()
        {
            string report = "";
            int countColoredEggs = eggs.Models.Count(x => x.IsDone());       

            report += $"{countColoredEggs} eggs are done!\r\n" +
                      $"Bunnies info:\r\n";

            foreach (var bunny in bunnies.Models)
            {
                var dyesNotFinished = bunny.Dyes.Count(x => !x.IsFinished());
                report += $"Name: {bunny.Name}\r\n" +
                          $"Energy: {bunny.Energy}\r\n" +
                          $"Dyes: {dyesNotFinished} not finished\r\n";
            }
            return report.TrimEnd();
        }
    }
}
