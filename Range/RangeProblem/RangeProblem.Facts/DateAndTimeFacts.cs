using Xunit;

namespace RangeProblem.Facts
{
    public class DateAndTimeFacts
    {
        [Fact]
        public void ValidDateTime()
        {
            var value = new DateAndTime();

            var actual = value.Match("( 31 )Dec( 1945 )00:12:35( (+)0245)");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void ValidDateTimeLeapYear()
        {
            var value = new DateAndTime();

            var actual = value.Match("( 29 )Feb( 3088 )00:12:35( (+)0245)");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void InvalidDate()
        {
            var value = new DateAndTime();

            var actual = value.Match("( 31 )Nov( 1945 )00:12:35( (+)0245)");

            Assert.False(actual.Success());
            Assert.Equal("( 31 )Nov( 1945 )00:12:35( (+)0245)", actual.RemainingText());
        }

        [Fact]
        public void InvalidDateLeapYear()
        {
            var value = new DateAndTime();

            var actual = value.Match("( 29 )Feb( 2021 )00:12:35( (+)0245)");

            Assert.False(actual.Success());
            Assert.Equal("( 29 )Feb( 2021 )00:12:35( (+)0245)", actual.RemainingText());
        }

        [Fact]
        public void InvalidTime()
        {
            var value = new DateAndTime();

            var actual = value.Match("( 31 )Oct( 2019 )00:70:35( (+)0245)");

            Assert.False(actual.Success());
            Assert.Equal("( 31 )Oct( 2019 )00:70:35( (+)0245)", actual.RemainingText());
        }
    }
}
