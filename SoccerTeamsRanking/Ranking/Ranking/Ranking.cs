using System;

namespace Ranking
{
    public class GeneralRanking
    {
        private SoccerTeam[] teams;

        public GeneralRanking(SoccerTeam[] teams)
        {
            this.teams = teams;
        }

        public void AddTeam(SoccerTeam newTeam)
        {
            if (newTeam is null)
            {
                return;
            }

            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = newTeam;
        }

        public SoccerTeam GetTeamAtPostion(int position)
        {
            GetGeneralRanking();
            return teams[position - 1];
        }

        public int GetTeamPosition(SoccerTeam team)
        {
            this.GetGeneralRanking();
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsNameEqual(team))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void UpdateTeamPoints(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsNameEqual(team))
                {
                    teams[i].AddPoints(team);
                }
            }
        }

        private static void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            SoccerTeam temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }

        private void GetGeneralRanking()
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = 0; j < teams.Length - 1; j++)
                {
                    if (teams[j].HasFewerPoint(teams[j + 1]))
                    {
                        Swap(teams, j, j + 1);
                    }
                }
            }
        }
    }
}
