using System;
using System.Collections.Generic;
using System.Linq;
using _07.MilitaryElite.Interfaces;
using _07.MilitaryElite.Models;

namespace _07.MilitaryElite
{
  
    public class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<ISoldier> soldiers = new List<ISoldier>();

            while (input != "End")
            {
                string[] soldiersData = input.Split();

                string soldierType = soldiersData[0];
                string id = soldiersData[1];
                string firtsName = soldiersData[2];
                string lastName = soldiersData[3];

                if (soldierType == "Private")
                {
                    decimal salary =decimal.Parse( soldiersData[4]);
                    Private @private = new Private(id, firtsName, lastName, salary);
                    soldiers.Add(@private);
                  
                }
                else if (soldierType == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldiersData[4]);

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firtsName, lastName, salary);
                  
                    //int privatesNumber = soldiersData.Length - 5;
                    for (int i =5; i < soldiersData.Length; i++)
                    {
                        string currentId = soldiersData[i];
                        if (soldiers.Any(x=>x.Id==currentId))
                        {
                            IPrivate @private =(IPrivate)soldiers.FirstOrDefault(x => x.Id == currentId);
                            lieutenantGeneral.AddPrivate(@private);
                        }       
                    }
                    soldiers.Add(lieutenantGeneral);
                }         
                else if (soldierType == "Engineer")
                {
                    decimal salary = decimal.Parse(soldiersData[4]);
                    string corp = soldiersData[5];
                    Engineer engineer = new Engineer(id, firtsName, lastName, salary, corp);
                    //int engineerData = soldiersData.Length - 6;
                    for (int i = 5; i < soldiersData.Length; i++)
                    { string[] repairData = soldiersData[i].Split();
                        string partName = repairData[0];
                        int repairHours =int.Parse( repairData[1]);
                        IRepair repair = new Repair(partName, repairHours);
                        engineer.AddRepair(repair);
                    }                   
                }
                else if (soldierType == "Commando")
                {
                    decimal salary = decimal.Parse(soldiersData[4]);
                    string corp = soldiersData[5];
                    Commando commando = new Commando(id, firtsName, lastName, salary, corp);
                    //int commandoData = soldiersData.Length - 6;
                    for (int i = 6; i < soldiersData.Length; i++)
                    {
                        string[] corpData = soldiersData[i].Split();
                        string missionName = corpData[0];

                        bool isValiState = Enum.TryParse(missionName, out State steteResult);
                        if (!isValiState)
                        {
                            continue;
                        }
                        IMission mission = new Mission(missionName, steteResult);
                        commando.AddMission(mission);
                    }
                }
                else if (soldierType == "Spy")
                {
                    int codeNumber = int.Parse(soldiersData[4]);

                    ISpy spy = new Spy(id, firtsName, lastName, codeNumber);
                    soldiers.Add(spy);
                }
                input = Console.ReadLine();

            }

            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
