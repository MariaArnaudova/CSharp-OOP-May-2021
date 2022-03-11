using EasterRaces.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EasterRaces.Repositories.Entities
{
    public abstract class Repository<T> : IRepository<T>
    {

        public List<T> Models { get; }
        //private List<T> models;
        public Repository()
        {
            this.Models = new List<T>();
        }
        public void Add(T model)
        {
            this.Models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return this.Models.AsReadOnly();
        }

        public abstract T GetByName(string name);
        //{
        //    T searchedCar = this.models.FirstOrDefault(x => x.Model == name);
        //    return searchedCar;
        //}

        public bool Remove(T model)
        {
            return this.Models.Remove(model);
        }
    }
}
