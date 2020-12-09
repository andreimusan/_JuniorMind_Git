using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class AnyFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var e = new Any("eE");

            var actual = e.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var e = new Any("eE");

            var actual = e.Match(string.Empty);

            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidString1()
        {
            var e = new Any("eE");

            var actual = e.Match("ea");

            Assert.True(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString2()
        {
            var e = new Any("eE");

            var actual = e.Match("Ea");

            Assert.True(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var e = new Any("eE");

            var actual = e.Match("a");

            Assert.False(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void IsNotNullSign()
        {
            var sign = new Any("-+");

            var actual = sign.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyStringWithSign()
        {
            var sign = new Any("-+");

            var actual = sign.Match(string.Empty);

            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringWithSign1()
        {
            var sign = new Any("-+");

            var actual = sign.Match("+3");

            Assert.True(actual.Success());
            Assert.Equal("3", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringWithSign2()
        {
            var sign = new Any("-+");

            var actual = sign.Match("-2");

            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidStringWithSign()
        {
            var sign = new Any("-+");

            var actual = sign.Match("2");

            Assert.False(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }
    }
}
