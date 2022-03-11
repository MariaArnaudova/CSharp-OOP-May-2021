using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
   public class RaceRepository : Repository<IRace>
    {    // class RaceRepository : IRepository<IRace>


        //private List<IRace> models;

        //public RaceRepository()
        //{
        //    this.models = new List<IRace>();
        //}

        //public void Add(IRace model)
        //{
        //    this.models.Add(model);
        //}

        //public IReadOnlyCollection<IRace> GetAll()
        //{
        //    return this.models;
        //}

        public override IRace GetByName(string name)
        {
            IRace searchedCar = this.Models.FirstOrDefault(x => x.Name == name);
            return searchedCar;
        }

        //public bool Remove(IRace model)
        //{
        //    return this.models.Remove(model);
        //}
    }
}
