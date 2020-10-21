﻿using System;

namespace Ranking
{
    public class GeneralRanking
    {
        private SoccerTeam[] teams;

        public GeneralRanking(SoccerTeam[] teams)
        {
            this.teams = teams;
            UpdateGeneralRanking();
        }

        enum GamePoints
        {
            Draw = 1,
            Win = 3
        }

        public void AddTeam(SoccerTeam newTeam)
        {
            if (newTeam is null)
            {
                return;
            }

            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsNameEqual(newTeam))
                {
                    return;
                }
            }

            Array.Resize(ref teams, teams.Length + 1);
            teams[^1] = newTeam;

            UpdateGeneralRanking();
        }

        public SoccerTeam GetTeamAtPostion(int position)
        {
            return teams[position - 1];
        }

        public int GetTeamPosition(SoccerTeam team)
        {
            for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].IsNameEqual(team))
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public void UpdateTeamPoints(SoccerTeam team1, SoccerTeam team2, int team1GameResult, int team2GameResult)
        {
            if (team1 == null || team2 == null)
            {
                return;
            }

            if (team1GameResult == team2GameResult)
            {
                team1.AddPoints((int)GamePoints.Draw);
                team2.AddPoints((int)GamePoints.Draw);
            }
            else if (team1GameResult > team2GameResult)
            {
                team1.AddPoints((int)GamePoints.Win);
            }
            else
            {
                team2.AddPoints((int)GamePoints.Win);
            }

            UpdateGeneralRanking();
        }

        private static void Swap(SoccerTeam[] teams, int firstIndex, int secondIndex)
        {
            SoccerTeam temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }

        private void UpdateGeneralRanking()
        {
            for (int i = 0; i < teams.Length - 1; i++)
            {
                for (int j = i + 1; j < teams.Length; j++)
                {
                    if (teams[i].HasFewerPoint(teams[j]))
                    {
                        Swap(teams, i, j);
                    }
                }
            }
        }
    }
}
