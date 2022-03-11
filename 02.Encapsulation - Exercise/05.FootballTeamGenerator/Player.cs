using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.FootballTeamGenerator
{
    public class Player
    {
        private const double StatsCount = 5.0;
        private Dictionary<string, int> stats = new Dictionary<string, int>()
        {
            {"endurance", 0},
            {"sprint", 0},
            {"dribble", 0},
            {"passing", 0},
            {"shooting", 0}
        };
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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
        public int Endurance
        {
            get => endurance;
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException($"{nameof(this.Endurance)} should be between 0 and 100.");
                }
                stats["endurance"] = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException($"{nameof(this.Sprint)} should be between 0 and 100.");
                }
                stats["sprint"] = value;
            }
        }

        public int Dribble
        {
            get => dribble;
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException($"{nameof(this.Dribble)} should be between 0 and 100.");
                }
                stats["dribble"] = value;
            }
        }

        public int Passing
        {
            get => passing;
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException($"{nameof(this.Passing)} should be between 0 and 100.");
                }
                stats["passing"] = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                if (value <= 0 || value >= 100)
                {
                    throw new ArgumentException($"{nameof(this.Shooting)} should be between 0 and 100.");
                }
                stats["shooting"] = value;
            }
        }

        private int SkillLevel => (int)Math.Round(stats.Select(x => x.Value).Sum() / StatsCount);
        public int GetSkillLevel
        {
           get => SkillLevel;
        }
    }
}
