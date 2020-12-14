using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class OneOrMoreFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var a = new OneOrMore(new Range('0', '9', ""));

            var actual = a.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var a = new OneOrMore(new Range('0', '9', ""));

            var actual = a.Match(string.Empty);

            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidString1()
        {
            var a = new OneOrMore(new Range('0', '9', ""));

            var actual = a.Match("123");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString2()
        {
            var a = new OneOrMore(new Range('0', '9', ""));

            var actual = a.Match("1a");

            Assert.True(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString3()
        {
            var a = new OneOrMore(new Range('0', '9', ""));

            var actual = a.Match("12a");

            Assert.True(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var a = new OneOrMore(new Range('0', '9', ""));

            var actual = a.Match("bc");

            Assert.False(actual.Success());
            Assert.Equal("bc", actual.RemainingText());
        }
    }
}
