using System;
using Xunit;

namespace Ranking.Facts
{
    public class SoccerTeamFacts
    {
        [Fact]
        public void CheckHasFewerPointWithSmallerValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);

            Assert.False(t1.HasFewerPoint(t2));
        }

        [Fact]
        public void CheckHasFewerPointWithBiggerValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 30);
            SoccerTeam t2 = new SoccerTeam("FCSB", 31);

            Assert.True(t1.HasFewerPoint(t2));
        }

        [Fact]
        public void CheckHasFewerPointWithEqualValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 36);

            Assert.False(t1.HasFewerPoint(t2));
        }

        [Fact]
        public void CheckHasFewerPointWithNullValue()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam(null, 0);

            Assert.False(t1.HasFewerPoint(t2));
        }

        [Fact]
        public void CheckIsNameEqualWithNullName()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam(null, 0);

            Assert.False(t1.IsNameEqual(t2));
        }

        [Fact]
        public void CheckIsNameEqualWithDifferentName()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("FCSB", 32);

            Assert.False(t1.IsNameEqual(t2));
        }

        [Fact]
        public void CheckIsNameEqualWithEqualName()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);
            SoccerTeam t2 = new SoccerTeam("CFR Cluj", 36);

            Assert.True(t1.IsNameEqual(t2));
        }

        [Fact]
        public void CheckAddPoints()
        {
            SoccerTeam t1 = new SoccerTeam("CFR Cluj", 36);

            Assert.Equal(40, t1.AddPoints(4));
        }
    }
}
