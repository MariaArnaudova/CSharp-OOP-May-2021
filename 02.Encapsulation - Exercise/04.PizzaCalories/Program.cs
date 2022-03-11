using System;

namespace _04.PizzaCalories
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string pizzaInput = Console.ReadLine().Split(" ")[1];

                string[] input = Console.ReadLine().Split(" ");

                string flourType = input[1];
                string backingTechique = input[2];

                double weight = double.Parse(input[3]);

                Dough dought = new Dough(flourType, backingTechique, weight);

                Pizza pizza = new Pizza(pizzaInput, dought);

                string command = Console.ReadLine();
                while (command != "END")
                {

                    string[] toppingInput = Console.ReadLine().Split(" ");

                    string toppingType = toppingInput[1];
                    double toppingWeight = double.Parse(toppingInput[2]);

                    Topping topping = new Topping(toppingType, toppingWeight);

                    pizza.AddTopping(topping);

                    command = Console.ReadLine();
                }

                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           


        }
    }
}
