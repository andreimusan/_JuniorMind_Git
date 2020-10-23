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

            Assert.False(digit.Match(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Character('0');

            Assert.False(digit.Match(string.Empty));
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Character('0');

            Assert.True(digit.Match("0ab"));
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Character('0');

            Assert.False(digit.Match("fab"));
        }
    }
}
