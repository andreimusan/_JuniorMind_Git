using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class TextClassFacts
    {
        [Fact]
        public void StringIsNotNull()
        {
            var trueValue = new Text("true");

            var actual = trueValue.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsAValidTrueString1()
        {
            var trueValue = new Text("true");

            var actual = trueValue.Match("true");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidTrueString2()
        {
            var trueValue = new Text("true");

            var actual = trueValue.Match("trueX");

            Assert.True(actual.Success());
            Assert.Equal("X", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidTrueString1()
        {
            var trueValue = new Text("true");

            var actual = trueValue.Match("false");

            Assert.False(actual.Success());
            Assert.Equal("false", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidTrueString2()
        {
            var trueValue = new Text("true");

            var actual = trueValue.Match(String.Empty);

            Assert.False(actual.Success());
            Assert.Equal(String.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidFalseString1()
        {
            var falseValue = new Text("false");

            var actual = falseValue.Match("false");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidFalseString2()
        {
            var falseValue = new Text("false");

            var actual = falseValue.Match("falseX");

            Assert.True(actual.Success());
            Assert.Equal("X", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidFalseString()
        {
            var trueValue = new Text("false");

            var actual = trueValue.Match("true");

            Assert.False(actual.Success());
            Assert.Equal("true", actual.RemainingText());
        }

        [Fact]
        public void IsAValidEmptyString()
        {
            var empty = new Text("");

            var actual = empty.Match("true");

            Assert.True(actual.Success());
            Assert.Equal("true", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidEmptyString()
        {
            var empty = new Text("");

            var actual = empty.Match(null);

            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }
    }
}
