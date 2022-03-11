using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private  List<IBunny> models;

        public BunnyRepository()
        {
            this.models = new List<IBunny>();
        }
        public IReadOnlyCollection<IBunny> Models
        {
            get
            {
                return this.models;
            }
            protected set { }
        }

        public void Add(IBunny Bunny)       
        {          
            models.Add(Bunny);
        }

        public IBunny FindByName(string name)
        {
            IBunny bunny = models.FirstOrDefault(x => x.Name == name);
            if (bunny ==null)
            {
                return null;
            }
            return bunny;
        }

        public bool Remove(IBunny model)
        {
            if (models.Remove(model))
            {
                return true;
            }
            return false;
        }
    }
}
