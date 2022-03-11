using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private string name;
        private int energy;
        //private  ICollection<IDye> dyes;

        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            Dyes = new List<IDye>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }


        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                if (value < 0)
                {
                    this.energy = 0;
                }
                else
                {
                    this.energy = value;
                }
            }
        }

        public ICollection<IDye> Dyes { get; protected set; }
        //{
        //    get
        //    {
        //        return this.dyes;
        //    }
        //    //private set { }
        //}

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }

        public abstract void Work();
        //{
        //    this.energy -= 10;
        //    if (this.energy < 0)
        //    {
        //        this.energy = 0;
        //    }
        //}

    }
}
