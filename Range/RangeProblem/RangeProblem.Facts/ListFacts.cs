using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class ListFacts
    {
        [Fact]
        public void IsAValidNull()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match(null);

            Assert.True(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsAValidEmptyString()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match(string.Empty);

            Assert.True(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidString1()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match("1,2,3");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString2()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match("1,2,3,");

            Assert.True(actual.Success());
            Assert.Equal(",", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString3()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match("1a");

            Assert.True(actual.Success());
            Assert.Equal("a", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString4()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match("abc");

            Assert.True(actual.Success());
            Assert.Equal("abc", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString5()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match("12a");

            Assert.True(actual.Success());
            Assert.Equal("2a", actual.RemainingText());
        }

        [Fact]
        public void IsAValidString6()
        {
            var a = new List(new Range('0', '9', ""), new Character(','));

            var actual = a.Match("1,2,34");

            Assert.True(actual.Success());
            Assert.Equal("4", actual.RemainingText());
        }

        [Fact]
        public void IsAValidList1()
        {
            var digits = new OneOrMore(new Range('0', '9', ""));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            var actual = list.Match("1; 22  ;\n 333 \t; 22");

            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidList2()
        {
            var digits = new OneOrMore(new Range('0', '9', ""));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            var actual = list.Match("1 \n;");

            Assert.True(actual.Success());
            Assert.Equal(" \n;", actual.RemainingText());
        }

        [Fact]
        public void IsAValidList3()
        {
            var digits = new OneOrMore(new Range('0', '9', ""));
            var whitespace = new Many(new Any(" \r\n\t"));
            var separator = new Sequence(whitespace, new Character(';'), whitespace);
            var list = new List(digits, separator);

            var actual = list.Match("abc");

            Assert.True(actual.Success());
            Assert.Equal("abc", actual.RemainingText());
        }
    }
}
