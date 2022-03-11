using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team(string name)
        {
            Name = name;
            players = new List<Player>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                this.name = value;
            }
        }


        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            Player playerToRemove = players.FirstOrDefault(x => x.Name == playerName);

            if (playerToRemove == null)
            {
                throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
            }
            this.players.Remove(playerToRemove);
        }

        public double TeamRating
        {
            get
            {
                int rating = 0;
                rating = players.Sum(x => x.GetSkillLevel / players.Count);
                if (rating == 0)
                {
                    return 0;
                }
                return rating;
            }

        }

    }
}
