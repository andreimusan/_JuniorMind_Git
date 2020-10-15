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

            Array.Resize(ref this.teams, this.teams.Length + 1);
            this.teams[this.teams.GetUpperBound(0)].Name = newTeam.Name;
            this.teams[this.teams.GetUpperBound(0)].Points = newTeam.Points;
        }

        public string GetTeamNameFromPosition(int position)
        {
            this.GetGeneralRanking();
            return teams[position - 1].Name;
        }

        public int GetTeamPosition(string toFind)
        {
            this.GetGeneralRanking();
            return this.GetTeamPosition(toFind, 0, this.teams.Length - 1);
        }

        private static void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            SoccerTeam temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }

        private int GetTeamPosition(string toFind, int start, int end)
        {
            if (start > end)
            {
                return -1;
            }

            int mid = (start + end) / 2;
            if (string.Compare(this.teams[mid].Name, toFind, true) == 0)
            {
                return mid;
            }

            return string.Compare(this.teams[mid].Name, toFind, true) < 0 ? this.GetTeamPosition(toFind, mid + 1, end)
                                          : this.GetTeamPosition(toFind, start, mid - 1);
        }

        private void GetGeneralRanking()
        {
            for (int i = 0; i < this.teams.Length - 1; i++)
            {
                for (int j = 0; j < this.teams.Length - 1; j++)
                {
                    if (this.teams[j].Points < this.teams[j + 1].Points)
                    {
                        Swap(this.teams, j, j + 1);
                    }
                }
            }
        }
    }
}
