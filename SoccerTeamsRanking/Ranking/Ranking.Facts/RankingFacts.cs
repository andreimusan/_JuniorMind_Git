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
            SoccerTeam t5 = new SoccerTeam("Astra Giurgiu", 25);

            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4 };
            SoccerTeam[] newTeams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);
            GeneralRanking newRanking = new GeneralRanking(newTeams);

            ranking.AddTeam(t5);

            Assert.Equal(ranking, newRanking);
        }

        [Fact]
        public void CheckTeamPositionFirst()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(1, ranking.GetTeamPosition(t5));
        }

        [Fact]
        public void CheckTeamPositionLast()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(5, ranking.GetTeamPosition(t4));
        }

        [Fact]
        public void CheckTeamPositionRandom()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(3, ranking.GetTeamPosition(t3));
        }

        [Fact]
        public void CheckTeamNameFirst()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal("FC Vaslui", ranking.GetTeamNameFromPosition(1));
        }

        [Fact]
        public void CheckTeamNameLast()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal("Dinamo", ranking.GetTeamNameFromPosition(5));
        }

        [Fact]
        public void CheckTeamNameRandom()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal("U Craiova", ranking.GetTeamNameFromPosition(3));
        }

        [Fact]
        public void CheckUpdateTeamPointsWithPositiveValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            SoccerTeam updateT3 = new SoccerTeam("U Craiova", 5);

            ranking.UpdateTeamPoints(updateT3);

            Assert.Equal(1, ranking.GetTeamPosition(t3));
        }

        [Fact]
        public void CheckUpdateTeamPointsWithNegativeValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            SoccerTeam updateT3 = new SoccerTeam("U Craiova", -10);

            ranking.UpdateTeamPoints(updateT3);

            Assert.Equal(5, ranking.GetTeamPosition(t3));
        }

        [Fact]
        public void CheckUpdateTeamPointsWithValueZero()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            SoccerTeam updateT3 = new SoccerTeam("U Craiova", 0);

            ranking.UpdateTeamPoints(updateT3);

            Assert.Equal(3, ranking.GetTeamPosition(t3));
        }
    }
}
