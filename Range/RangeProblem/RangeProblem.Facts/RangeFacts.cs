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

            Assert.False(digit.Match(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Range('a', 'f');

            Assert.False(digit.Match(string.Empty));
        }

        [Fact]
        public void IsAValidString()
        {
            var digit = new Range('a', 'f');

            Assert.True(digit.Match("fab"));
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Range('a', 'f');

            Assert.False(digit.Match("1ab"));
        }
    }
}
