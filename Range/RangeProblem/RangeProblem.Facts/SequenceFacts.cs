using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RangeProblem.Facts
{
    public class SequenceFacts
    {
        [Fact]
        public void IsNotNull()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var actual = ab.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var actual = ab.Match(String.Empty);
            Assert.False(actual.Success());
            Assert.Equal(String.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringSequence1()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var actual = ab.Match("abcd");
            Assert.True(actual.Success());
            Assert.Equal("cd", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidStringSequence1()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var actual = ab.Match("ax");
            Assert.False(actual.Success());
            Assert.Equal("ax", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidStringSequence2()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var actual = ab.Match("def");
            Assert.False(actual.Success());
            Assert.Equal("def", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidStringSequence3()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var actual = ab.Match("");
            Assert.False(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringSequence2()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            var actual = abc.Match("abcd");
            Assert.True(actual.Success());
            Assert.Equal("d", actual.RemainingText());
        }
    }
}
