using System;
using System.Collections.Generic;
using System.Linq;

namespace BirthdayCelebrations
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IBirthdate> habitantBirthdays = new List<IBirthdate>();

            while (input != "End")
            {
                string[] objectData = input.Split();

                string habitant = objectData[0];

                if (habitant == "Citizen")
                {
                    string citizenName = objectData[1];
                    int citizenAge = int.Parse(objectData[2]);
                    string citizenId = objectData[3];
                    string citizenBirthday = objectData[4];
                    IBirthdate citizen = new Citizen(habitant, citizenId, citizenAge, citizenBirthday);
                    habitantBirthdays.Add(citizen);

                }
                else if (habitant == "Pet")
                {
                    string petName = objectData[1];
                    string petBirthDay = objectData[2];
                    IBirthdate pet = new Pet(petName, petBirthDay);
                    habitantBirthdays.Add(pet);
                }

                input = Console.ReadLine();
            }

            string year = Console.ReadLine();

            habitantBirthdays = habitantBirthdays
                .Where(x => x.Birthdate.EndsWith(year))
                .ToList();

            foreach (var habitant in habitantBirthdays)
            {
                Console.WriteLine(habitant);

            }
        }
    }
}

