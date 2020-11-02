using System;
using Xunit;

namespace RangeProblem.Facts
{
    public class CharacterFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var digit = new Character('0');
            var actual = digit.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Character('0');
            var actual = digit.Match(string.Empty);
            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Character('0');
            var actual = digit.Match("0ab");
            Assert.True(actual.Success());
            Assert.Equal("ab", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Character('0');
            var actual = digit.Match("fab");
            Assert.False(actual.Success());
            Assert.Equal("fab", actual.RemainingText());
        }
    }
}
