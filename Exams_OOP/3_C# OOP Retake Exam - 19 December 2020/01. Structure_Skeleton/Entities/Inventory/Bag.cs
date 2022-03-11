using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private readonly List<Item> items;

        protected Bag(int capacity)
        {
            this.items = new List<Item>();
            this.Capacity = capacity;
        }
        public int Capacity { get; set; } = DefaultCapacity; // ??? pravilno implementirane

        public int Load => this.items.Sum(x => x.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.ExceedMaximumBagCapacity));
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);

            if (items.Count==0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.EmptyBag));
            }

            if (!this.items.Any(x=>x.GetType().Name==name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            this.items.Remove(item);
            return item;
        }
    }
}
