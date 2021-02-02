using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class ValueFacts
    {
        [Fact]
        public void IsNumberZero()
        {
            var value = new Value();

            var actual = value.Match("0");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsNumber()
        {
            var value = new Value();

            var actual = value.Match("-26");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsString()
        {
            var value = new Value();

            var actual = value.Match("\"abc\"");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsTextTrue()
        {
            var value = new Value();

            var actual = value.Match("true");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsTextFalse()
        {
            var value = new Value();

            var actual = value.Match("false");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsTextNull()
        {
            var value = new Value();

            var actual = value.Match("null");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsSimpleArray()
        {
            var value = new Value();

            var actual = value.Match("[12]");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsComplexArray()
        {
            var value = new Value();

            var actual = value.Match("[12, \"value\", 4, true]");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsEmptyArray()
        {
            var value = new Value();

            var actual = value.Match("[ ]");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsSimpleObject()
        {
            var value = new Value();

            var actual = value.Match("{\"value\": \"New\"}");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsComplexObject()
        {
            var value = new Value();

            var actual = value.Match("{\"value\": \"Open\", \"onclick\": \"OpenDoc()\"}");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsEmptyObject()
        {
            var value = new Value();

            var actual = value.Match("{ \r }");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidJSON()
        {
            var value = new Value();
            var jsonText = "[ { \"dose\": \"\", \"strength\": [ 500, 100, 200 ] }, { \"type\": \"donut\", \"name\": \"Cake\" } ]";

            var actual = value.Match(jsonText);

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }
    }
}
