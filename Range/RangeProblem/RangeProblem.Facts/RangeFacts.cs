using System;
using Xunit;

namespace RangeProblem.Facts
{
    public class RangeFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var digit = new Range('a', 'f');

            Assert.Equal(digit.Match(null).RemainingText(), new FailedMatch(null).RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Range('a', 'f');

            Assert.True(Object.ReferenceEquals(digit.Match(string.Empty).RemainingText(), new FailedMatch(string.Empty).RemainingText()));
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Range('a', 'f');
            var text = "fab";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text.Substring(1)).RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Range('a', 'f');
            var text = "1ab";

            Assert.True(Object.ReferenceEquals(digit.Match(text).RemainingText(), new FailedMatch(text).RemainingText()));
        }
    }
}
