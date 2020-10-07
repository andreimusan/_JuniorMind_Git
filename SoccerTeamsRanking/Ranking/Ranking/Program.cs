using System;

namespace Ranking
{
    class Program
    {
        public class SoccerTeam
        {
            public string Name;
            public int Points;

            public SoccerTeam(string name, int points)
            {
                this.Name = name;
                this.Points = points;
            }
        }

        public class Ranking
        {
            private SoccerTeam[] teams;

            public Ranking(SoccerTeam[] teams)
            {
                this.teams = teams;
            }

            public static void AddTeam(SoccerTeam newTeam)
            {
                Array.Resize(ref teams, teams.Length + 1);
                teams[teams.GetUpperBound(0)].Name = newTeam.Name;
                teams[teams.GetUpperBound(0)].Points = newTeam.Points;
            }

            public static void GeneralRanking()
            {
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    for (int j = 0; j < teams.Length - 1; j++)
                    {
                        if (teams[j].Points < teams[j + 1].Points)
                        {
                            Swap(teams, j, j + 1);
                        }
                    }
                }
            }
        }

        static void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            SoccerTeam temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }
    }
}
