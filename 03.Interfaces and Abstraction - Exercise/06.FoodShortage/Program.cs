using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, IBuyer> byers = new Dictionary<string, IBuyer>();

            for (int i = 0; i < n; i++)
            {
                string[] nativesData = Console.ReadLine()
                    .Split();

                string name = nativesData[0];
                int age = int.Parse(nativesData[1]);
                int startFood = 0;

                if (nativesData.Length == 4)
                {
                    string citizenId = nativesData[2];
                    string citizenBirthday = nativesData[3];
                    IBuyer citizen = new Citizen(name, age, citizenId, citizenBirthday, startFood);
            
                    if (!byers.ContainsKey(name))
                    {
                        byers.Add(name, citizen);
                    }
                }
                else if (nativesData.Length == 3)
                {
                    string group = nativesData[2];
                    IBuyer rebel = new Rebel(name, age, group, startFood);
                  
                    if (!byers.ContainsKey(name))
                    {
                        byers.Add(name, rebel);
                    }
                }
            }

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (byers.ContainsKey(input))
                {
                    byers[input].BuyFood();
                }
                input = Console.ReadLine();
            }

            int food = byers.Sum(x => x.Value.Food);


            Console.WriteLine(food);
   
        }
    }
}

