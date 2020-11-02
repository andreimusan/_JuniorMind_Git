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

            Assert.True(Object.Equals(digit.Match(null).RemainingText(), new FailedMatch(null).RemainingText()));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Character('0');

            Assert.Equal(digit.Match(string.Empty).RemainingText(), new FailedMatch(string.Empty).RemainingText());
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Character('0');
            var text = "0ab";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text.Substring(1)).RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Character('0');
            var text = "fab";

            Assert.Equal(digit.Match(text).RemainingText(), new FailedMatch(text).RemainingText());
        }
    }
}
