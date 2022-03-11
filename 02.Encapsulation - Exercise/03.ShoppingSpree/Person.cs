using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            bag = new List<Product>();
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
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }

        }
        public decimal Money
        {
            get
            {
                return this.money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void AddToBag(Product product)
        {
            if (this.money - product.Cost >= 0)
            {
                bag.Add(product);
                this.Money -= product.Cost;
                Console.WriteLine($"{Name} bought {product.Name}");
            }
            else
            {
                Console.WriteLine($"{Name} can't afford {product.Name}");
            }
        }
        public override string ToString()
        {
            if (this.bag.Count==0)
            {
                return $"{this.Name} - Nothing bought";
            }
            return $"{this.Name} - {String.Join(", ", this.Bag.Select(x => x.Name))}";
        }
    }
}
