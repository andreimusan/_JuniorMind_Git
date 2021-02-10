using Xunit;

namespace RangeProblem.Facts
{
    public class DateAndTimeFacts
    {
        [Fact]
        public void ValidDateTimeLong()
        {
            var value = new DateAndTime();

            var actual = value.Match("   Mon, 31 Dec 1756 00:12:35 +0245");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ValidDateTimeShort()
        {
            var value = new DateAndTime();

            var actual = value.Match("29 Feb 3088 00:12 -0000");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void InvalidDate()
        {
            var value = new DateAndTime();

            var actual = value.Match("31Dec175600:12:35+0245");

            Assert.False(actual.Success());
            Assert.Equal("31Dec175600:12:35+0245", actual.RemainingText());
        }

        [Fact]
        public void InvalidTime()
        {
            var value = new DateAndTime();

            var actual = value.Match("29 Feb 3088 00:12:152 -0000");

            Assert.False(actual.Success());
            Assert.Equal("29 Feb 3088 00:12:152 -0000", actual.RemainingText());
        }

        [Fact]
        public void InvalidZone()
        {
            var value = new DateAndTime();

            var actual = value.Match(" 31 Dec 1756 00:12:35 0245");

            Assert.False(actual.Success());
            Assert.Equal(" 31 Dec 1756 00:12:35 0245", actual.RemainingText());
        }
    }
}
