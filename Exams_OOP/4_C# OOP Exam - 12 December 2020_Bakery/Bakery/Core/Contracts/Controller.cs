using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {

        private List<IBakedFood> bakedFoods;
        private List<IDrink> drinks;
        private List<ITable> tables;
        private decimal totalIncome = 0;

        public Controller()
        {
            this.bakedFoods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }
        public string AddDrink(string type, string name, int portion, string brand)
        {
            if (type == "Tea")
            {
                IDrink newDrink = new Tea(name, portion, brand);
                this.drinks.Add(newDrink);
            }
            else if (type == "Water")
            {
                IDrink newDrink = new Water(name, portion, brand);
                this.drinks.Add(newDrink);
            }
            return $"Added {name} ({brand}) to the drink menu";
        }

        public string AddFood(string type, string name, decimal price)
        {
            if (type == "Bread")
            {
                IBakedFood newFood = new Bread(name, price);
                this.bakedFoods.Add(newFood);
            }
            else if (type == "Cake")
            {
                IBakedFood newFood = new Cake(name, price);
                this.bakedFoods.Add(newFood);
            }

            return $"Added {name} ({type}) to the menu";
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            if (type == "InsideTable")
            {
                ITable newTable = new InsideTable(tableNumber, capacity);
                this.tables.Add(newTable);
            }
            else if (type == "OutsideTable")
            {
                ITable newTable = new OutsideTable(tableNumber, capacity);
                this.tables.Add(newTable);
            }

            return $"Added table number {tableNumber} in the bakery";
        }

        public string GetFreeTablesInfo()
        {
            var availableTables = tables.Where(x => x.IsReserved == false).ToList();
            string allTablesInfo = "";
            foreach (ITable table in availableTables)
            {
                allTablesInfo += table.GetFreeTableInfo() + Environment.NewLine;
            }
            return allTablesInfo.TrimEnd();
        }

        public string GetTotalIncome()
        {
            
            return $"Total income: {totalIncome:f2}lv";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable availableTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);
            decimal bill = availableTable.GetBill();
            totalIncome += bill;
            availableTable.Clear();

            string tableBill = "";

            return tableBill = $"Table: {tableNumber}" + Environment.NewLine
                             + $"Bill: {bill:f2}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable availableTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (availableTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
                if (drink == null)
                {
                    return $"There is no {drinkName} {drinkBrand} available";
                }
                else
                {
                    availableTable.OrderDrink(drink);
                    return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
                }
            }
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable availableTable = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (availableTable == null)
            {
                return $"Could not find table {tableNumber}";
            }
            else
            {
                IBakedFood food = bakedFoods.FirstOrDefault(x => x.Name == foodName);
                if (food == null)
                {
                    return $"No {foodName} in the menu";
                }
                else
                {
                    availableTable.OrderFood(food);
                    return $"Table {tableNumber} ordered {foodName}";
                }
            }
        }

        public string ReserveTable(int numberOfPeople)
        {

            ITable availableTable = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);
            if (availableTable == null)
            {
                return $"No available table for {numberOfPeople} people";
            }
            else 
            {
                availableTable.Reserve(numberOfPeople);
                return $"Table {availableTable.TableNumber} has been reserved for {numberOfPeople} people";
            }

        }
    }
}
