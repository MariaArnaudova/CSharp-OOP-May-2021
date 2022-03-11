using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonsInfo
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Person> persons = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] personArguments = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = new Person(personArguments[0]
                    , personArguments[1]
                    , int.Parse(personArguments[2]));

                persons.Add(person);
            }

            persons = persons.OrderBy(p => p)
                .ThenBy(p => p.Age)
                .ToList();

            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }
        }
    }
}
