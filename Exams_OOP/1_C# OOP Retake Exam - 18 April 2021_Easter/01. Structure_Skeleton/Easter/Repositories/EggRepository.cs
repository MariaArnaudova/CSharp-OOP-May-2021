using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
   public class EggRepository: IRepository<IEgg>
    {
        private List<IEgg> models;

        public EggRepository()
        {
            this.models = new List<IEgg>();
        }
        public IReadOnlyCollection<IEgg> Models
        {
            get
            {
                return this.models;
            }
        }
        public void Add(IEgg Egg)
        {
            models.Add(Egg);
        }

        public IEgg FindByName(string name)
        {
            IEgg egg = models.FirstOrDefault(x => x.Name == name);
            if (egg == null)
            {
                return null;
            }
            return egg;
        }

        public bool Remove(IEgg egg)
        {
            if (models.Remove(egg))
            {
                return true;
            }
            return false;
        }
    }
}
