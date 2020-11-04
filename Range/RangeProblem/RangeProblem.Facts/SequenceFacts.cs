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

        [Fact]
        public void IsNotAValidStringSequence4()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            var actual = abc.Match("def");
            Assert.False(actual.Success());
            Assert.Equal("def", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidStringSequence5()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            var actual = abc.Match("abx");
            Assert.False(actual.Success());
            Assert.Equal("abx", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidStringSequence6()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            var actual = abc.Match("");
            Assert.False(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsNotNullSequence()
        {
            var ab = new Sequence(
                new Character('a'),
                new Character('b')
            );

            var abc = new Sequence(
                ab,
                new Character('c')
            );

            var actual = abc.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsAValidHexSequence1()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            var actual = hexSeq.Match("u1234");
            Assert.True(actual.Success());
            Assert.Equal("", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHexSequence2()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            var actual = hexSeq.Match("uabcdef");
            Assert.True(actual.Success());
            Assert.Equal("ef", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHexSequence3()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            var actual = hexSeq.Match("uB005 ab");
            Assert.True(actual.Success());
            Assert.Equal(" ab", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidHexSequence()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            var actual = hexSeq.Match("abc");
            Assert.False(actual.Success());
            Assert.Equal("abc", actual.RemainingText());
        }

        [Fact]
        public void IsNotNullHexSequence()
        {
            var hex = new Choice(
                new Range('0', '9'),
                new Range('a', 'f'),
                new Range('A', 'F')
            );

            var hexSeq = new Sequence(
                new Character('u'),
                new Sequence(
                    hex,
                    hex,
                    hex,
                    hex
                )
            );

            var actual = hexSeq.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }
    }
}
