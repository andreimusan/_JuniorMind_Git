using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class OptionlFacts
    {
        [Fact]
        public void IsAValidNull()
        {
            var a = new Optional(new Character('a'));

            var actual = a.Match(null);

            Assert.True(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsAValidEmptyString()
        {
            var a = new Optional(new Character('a'));

            var actual = a.Match(string.Empty);

            Assert.True(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidString1()
        {
            var a = new Optional(new Character('a'));

            var actual = a.Match("abc");

            Assert.True(actual.Success());
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString2()
        {
            var a = new Optional(new Character('a'));

            var actual = a.Match("aabc");

            Assert.True(actual.Success());
            Assert.Equal("abc", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString3()
        {
            var a = new Optional(new Character('a'));

            var actual = a.Match("bc");

            Assert.True(actual.Success());
            Assert.Equal("bc", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringWithDigits1()
        {
            var digits = new Optional(new Character('-'));

            var actual = digits.Match("123");

            Assert.True(actual.Success());
            Assert.Equal("123", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringWithDigits2()
        {
            var digits = new Optional(new Character('-'));

            var actual = digits.Match("-123");

            Assert.True(actual.Success());
            Assert.Equal("123", actual.RemainingText());
        }
    }
}
