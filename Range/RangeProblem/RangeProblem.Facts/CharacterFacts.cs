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

            Assert.Equal(digit.Match(null), new FailedMatch(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Character('0');

            Assert.Equal(digit.Match(string.Empty), new FailedMatch(string.Empty));
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Character('0');
            var text = "0ab";

            Assert.Equal(digit.Match(text), new SuccessMatch(text));
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Character('0');
            var text = "fab";

            Assert.Equal(digit.Match(text), new FailedMatch(text));
        }
    }
}
