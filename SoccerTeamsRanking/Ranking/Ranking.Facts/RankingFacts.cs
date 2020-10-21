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

            GeneralRanking ranking = new GeneralRanking(teams);

            ranking.AddTeam(t5);

            Assert.Equal(4, ranking.GetTeamPosition(t5));
        }

        [Fact]
        public void CheckAddNewTeamToNotAddSameTeam()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FCSB", 25);

            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4 };

            GeneralRanking ranking = new GeneralRanking(teams);

            ranking.AddTeam(t5);

            Assert.Equal(4, ranking.GetTeamPosition(t4));
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
        public void CheckGetTeamAtPostionFirst()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(t5, ranking.GetTeamAtPostion(1));
        }

        [Fact]
        public void CheckGetTeamAtPostionLast()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(t4, ranking.GetTeamAtPostion(5));
        }

        [Fact]
        public void CheckGetTeamAtPostionRandom()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            Assert.Equal(t3, ranking.GetTeamAtPostion(3));
        }

        [Fact]
        public void CheckUpdateTeamPointsWithDrawValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 35);
            SoccerTeam t2 = new SoccerTeam("FCSB", 32);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 31);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            ranking.UpdateTeamPoints(t3, t4, 2, 2);

            Assert.Equal(4, ranking.GetTeamPosition(t3));
        }

        [Fact]
        public void CheckUpdateTeamPointsWithWinValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 34);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);
            SoccerTeam t3 = new SoccerTeam("U Craiova", 32);
            SoccerTeam t4 = new SoccerTeam("Dinamo", 24);
            SoccerTeam t5 = new SoccerTeam("FC Vaslui", 36);
            SoccerTeam[] teams = new SoccerTeam[] { t1, t2, t3, t4, t5 };

            GeneralRanking ranking = new GeneralRanking(teams);

            ranking.UpdateTeamPoints(t2, t3, 0, 2);

            Assert.Equal(2, ranking.GetTeamPosition(t3));
        }
    }
}
