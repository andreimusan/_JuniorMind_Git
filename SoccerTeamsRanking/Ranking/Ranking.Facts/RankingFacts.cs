using System;
using Xunit;

namespace Ranking.Facts
{
    public class RankinFacts
    {
        [Fact]
        public void CheckAddNewTeam()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4 };

            GeneralRanking ranking = new GeneralRanking(teams);

            SoccerTeam t6 = new SoccerTeam("Astra Giurgiu", 25);
            SoccerTeam[] newTeams = new SoccerTeam[] { t1, t2, t3, t4, t6 };

            GeneralRanking newRanking = new GeneralRanking(newTeams);

            ranking.AddTeam(t6);

            Assert.Equal(ranking, newRanking);
        }

        [Fact]
        public void CheckTeamPosition()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(1, ranking.GetTeamPosition("CFR Cluj"));
        }

        [Fact]
        public void CheckTeamName()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal("CFR Cluj", ranking.GetTeamNameFromPosition(1));
        }
    }
}
