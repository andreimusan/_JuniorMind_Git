using System;
using Xunit;

namespace RangeProblem.Facts
{
    public class ChoiceFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.False(digit.Match(null));
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.False(digit.Match(string.Empty));
        }

        [Fact]
        public void IsAValidStringDigit1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.True(digit.Match("012"));
        }

        [Fact]
        public void IsAValidStringDigit2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.True(digit.Match("12"));
        }

        [Fact]
        public void IsAValidStringDigit3()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.True(digit.Match("92"));
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.False(digit.Match("a9"));
        }
    }
}
