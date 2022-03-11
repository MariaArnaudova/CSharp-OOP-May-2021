using System;
using System.Collections.Generic;

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
                try
                {
                    Person person = new Person(personArguments[0],
                 personArguments[1],
                 int.Parse(personArguments[2]),
                 decimal.Parse(personArguments[3]));

                    persons.Add(person);
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

            Team team = new Team("SoftUni");

            foreach (Person person in persons)
            {
                team.AddPlayer(person);
            }

            Console.WriteLine($"First team has { team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has { team.ReserveTeam.Count} players.");
        }
    }
}
