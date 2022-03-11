using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {

        public void Color(IEgg egg, IBunny bunny)
        {

            if (bunny.Dyes.Any(x => !x.IsFinished()))
            {

                IDye dye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());

                while (!egg.IsDone())
                {
                   
                    if (dye.IsFinished())
                    {
                        dye = bunny.Dyes.FirstOrDefault(x => !x.IsFinished());
                     
                    }

                    if (bunny.Energy == 0)
                    {
                        break;
                    }

                    if (bunny.Dyes.All(x => x.IsFinished()))
                    {
                        break;
                    }


                    dye.Use();
                    egg.GetColored();
                    bunny.Work();
                }
            }

        }
    }
}
