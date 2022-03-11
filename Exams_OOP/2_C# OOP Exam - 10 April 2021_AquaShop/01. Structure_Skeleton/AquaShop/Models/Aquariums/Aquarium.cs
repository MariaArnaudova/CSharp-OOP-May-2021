using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private  List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAquariumName);
                }

                this.name = value;
            }
        }
        public int Capacity { get { return this.capacity; } private set { } }

        public int Comfort
        {
            get
            {
                return this.Decorations.Sum(d => d.Comfort);
            }
        }

        public ICollection<IDecoration> Decorations { get { return this.decorations; }  }
                                                     //=> this.decorations; 
        public ICollection<IFish> Fish { get { return this.fish; } }

        public void AddDecoration(IDecoration decoration)
        {
            this.Decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if (this.Capacity <= this.Fish.Count) /// da proveria ravnoto
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }

            this.fish.Add(fish);
        }

        public void Feed()
        {
            foreach (IFish fish in this.Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.Fish.Count == 0)
            {
                sb.AppendLine($"Fish: none");
                sb.AppendLine($"Decorations: { Decorations.Count}");
                sb.AppendLine($"Comfort: { this.Comfort}");
                return sb.ToString().TrimEnd();
            }

            sb.AppendLine($"Fish: { string.Join(", ", this.Fish.Select(x => x.Name))}");
            sb.AppendLine($"Decorations: { Decorations.Count}");
            sb.AppendLine($"Comfort: { this.Comfort}");

            return sb.ToString().TrimEnd();

        }

        public bool RemoveFish(IFish fish)
        {
            if (this.Fish.Remove(fish))
            {
                return true;
            }
            return false;
        }
    }
}
