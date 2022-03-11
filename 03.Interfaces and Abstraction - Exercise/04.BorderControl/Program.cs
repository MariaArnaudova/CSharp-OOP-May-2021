using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<IIdentifiable> citizzenAndRobots = new List<IIdentifiable>();

            while (input != "End")
            {
                string[] objectData = input.Split();

                string name = objectData[0];

                if (objectData.Length == 3)
                {   
                    int citizenAge = int.Parse(objectData[1]);
                    string citizenId = objectData[2];
                    IIdentifiable citizen = new Citizen(name,  citizenId, citizenAge);
                    citizzenAndRobots.Add(citizen);
        
                }
                else if (objectData.Length == 2)
                {
                    string robotModel = name;
                    string robotId = objectData[1];
                    IIdentifiable robot = new Robot(robotModel, robotId);
                    citizzenAndRobots.Add(robot);
                }

                input = Console.ReadLine();
            }

            string lastDigitOfFake = Console.ReadLine();

            citizzenAndRobots = citizzenAndRobots
                .Where(x => x.Id.EndsWith(lastDigitOfFake))
                .ToList();
        
            foreach (var legalCitizen in citizzenAndRobots)
            {
                Console.WriteLine(legalCitizen.Id);
     
            }
        }

        //public bool CheckToFakesId(string endNumbers, string id)
        //{
        //    string idToString = id.ToString();
        //    string chekedString = idToString.Substring(idToString.Length - 3);
        //    if (chekedString == endNumbers)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}
