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

            Assert.Equal(digit.Match(null), new FailedMatch(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Range('a', 'f');

            Assert.Equal(digit.Match(string.Empty), new FailedMatch(string.Empty));
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Range('a', 'f');
            var text = "fab";

            Assert.Equal(digit.Match(text), new SuccessMatch(text));
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Range('a', 'f');
            var text = "1ab";

            Assert.Equal(digit.Match(text), new FailedMatch(text));
        }
    }
}
