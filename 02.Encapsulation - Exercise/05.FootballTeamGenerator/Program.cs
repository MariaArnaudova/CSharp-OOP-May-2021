using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            try
            {
                List<Team> teams = new List<Team>();

                string input = Console.ReadLine();

                while (input != "END")
                {
                    string[] tokens = input.Split(';');
                    string command = tokens[0];
                    string currentTeam = tokens[1];

                    if (command == "Team")
                    {
                        Team team = new Team(currentTeam);
                        teams.Add(team);
                    }
                    else if (command == "Add")
                    {

                        if (teams.Any(x => x.Name == currentTeam))
                        {
                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);
                            try
                            {
                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                Team searchedTeam = teams.FirstOrDefault(x => x.Name == currentTeam);
                                searchedTeam.AddPlayer(player);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);
                   
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {currentTeam} does not exist.");
                        }
                    }
                    else if (command == "Remove")
                    {
                        if (teams.Any(x => x.Name == currentTeam))
                        {
                            try
                            {
                                string playerName = tokens[2];
                                Team searchedTeam = teams.FirstOrDefault(x => x.Name == currentTeam);
                                searchedTeam.RemovePlayer(playerName);
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);

                            }
                        }
                        else
                        {

                            Console.WriteLine($"Team {currentTeam} does not exist.");

                        }

                    }
                    else if (command == "Rating")
                    {
                        if (teams.Any(x => x.Name == currentTeam))
                        {
                            try
                            {
                                Team searchedTeam = teams.FirstOrDefault(x => x.Name == currentTeam);
                                Console.WriteLine($"{currentTeam} - {searchedTeam.TeamRating}");
                            }
                            catch (Exception ex)
                            {

                                Console.WriteLine(ex.Message);

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Team {currentTeam} does not exist.");
                        }
                       
                    }

                    input = Console.ReadLine();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
