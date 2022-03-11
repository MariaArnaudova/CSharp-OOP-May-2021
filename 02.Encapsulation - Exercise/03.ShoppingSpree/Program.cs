using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
  public  class Program
    {
        static void Main(string[] args)
        {
        
            try
            {
                List<Person> people = new List<Person>();
                List<Product> products = new List<Product>();

                string[] personsInfo = Console.ReadLine()
         .Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < personsInfo.Length; i++)
                {
                    string[] personMoneyName = personsInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string personName = personMoneyName[0];
                    decimal personMoney = decimal.Parse(personMoneyName[1]);
                    Person person = new Person(personName, personMoney);
                    people.Add(person);
                }
                string[] productInfo = Console.ReadLine()
                  .Split(";", StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < productInfo.Length; i++)
                {
                    string[] productPriceName = productInfo[i].Split("=", StringSplitOptions.RemoveEmptyEntries);
                    string productName = productPriceName[0];
                    decimal productPrice = decimal.Parse(productPriceName[1]);
                    Product product = new Product(productName, productPrice);
                    products.Add(product);
                }

                while (true)
                {
                    string input = Console.ReadLine();
                    if (input == "END")
                    {
                        break;
                    }

                    string[] personProduct = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string name = personProduct[0];
                    string product = personProduct[1];


                    Person person = people.FirstOrDefault(p => p.Name == name);
                    Product currentProduct = products.FirstOrDefault(p => p.Name == product);

                    person.AddToBag(currentProduct);

                }

                foreach (var currentPerson in people)
                {
                    Console.WriteLine(currentPerson);
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
    }
}
