using System;
using Xunit;

namespace RangeProblem.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var digit = new Range('a', 'f', "");
            var actual = digit.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Range('a', 'f', "");
            var actual = digit.Match(string.Empty);
            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Range('a', 'f', "");
            var actual = digit.Match("fab");
            Assert.True(actual.Success());
            Assert.Equal("ab", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Range('a', 'f', "");
            var actual = digit.Match("1ab");
            Assert.False(actual.Success());
            Assert.Equal("1ab", actual.RemainingText());
        }

        [Fact]
        public void IsNotValueOne()
        {
            var digit = new Range('0', '9', "1");
            var actual = digit.Match("1ab");
            Assert.False(actual.Success());
            Assert.Equal("1ab", actual.RemainingText());
        }
    }
}
