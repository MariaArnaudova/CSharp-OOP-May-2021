using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
   public class DriverRepository: Repository<IDriver>
    {   ////class DriverRepository : IRepository<IDriver>

        //private List<IDriver> models;

        //public DriverRepository()
        //{
        //    this.models = new List<IDriver>(); 
        //}

        //public void Add(IDriver model)
        //{
        //    this.models.Add(model);
        //}

        //public IReadOnlyCollection<IDriver> GetAll()
        //{
        //    return this.models;
        //}

        public override IDriver GetByName(string name)
        {
            IDriver searchedCar = this.Models.FirstOrDefault(x => x.Name == name);
            return searchedCar;
        }

        //public bool Remove(IDriver model)
        //{
        //    return this.models.Remove(model);
        //}
    }
}
