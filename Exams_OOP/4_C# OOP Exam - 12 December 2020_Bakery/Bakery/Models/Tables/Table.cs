
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
        }
        public int TableNumber { get; private set; }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public bool IsReserved { get; private set; }

        public decimal Price
        {
            get { return this.NumberOfPeople * this.PricePerPerson; }
        }

        public SerializationInfo ExceptionMessage { get; private set; }

        public void Clear()
        {
            IsReserved = false;
            foodOrders.Clear();
            drinkOrders.Clear();
            numberOfPeople = 0;
        }

        public decimal GetBill()
        {
            decimal bill = foodOrders.Sum(x => x.Price) 
                           + drinkOrders.Sum(x => x.Price)
                           +Price;
            return bill;
        }

        public string GetFreeTableInfo()
        {
            string tableInfo = "";
            return tableInfo = $"Table: {TableNumber}" + Environment.NewLine
                       + $"Type: {this.GetType().Name}" + Environment.NewLine
                       + $"Capacity: {Capacity}" + Environment.NewLine
                       + $"Price per Person: {PricePerPerson}";
            //  + $"Price per Person: {PricePerPerson}\r\n"+;
        }

        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            this.NumberOfPeople += numberOfPeople;
        }
    }
}

