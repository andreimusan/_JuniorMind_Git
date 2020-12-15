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

            var actual = digit.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match(string.Empty);
            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("012");
            Assert.True(actual.Success());
            Assert.Equal("12", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("12");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit3()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("92");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var actual = digit.Match("a9");
            Assert.False(actual.Success());
            Assert.Equal("a9", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("012");
            Assert.True(actual.Success());
            Assert.Equal("12", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("12");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex3()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("92");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex4()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("a9");
            Assert.True(actual.Success());
            Assert.Equal("9", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex5()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("f8");
            Assert.True(actual.Success());
            Assert.Equal("8", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex6()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("A9");
            Assert.True(actual.Success());
            Assert.Equal("9", actual.RemainingText());
        }

        [Fact]
        public void IsAValidHex7()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("F8");
            Assert.True(actual.Success());
            Assert.Equal("8", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidHex1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("g8");
            Assert.False(actual.Success());
            Assert.Equal("g8", actual.RemainingText());
        }

        [Fact]
        public void IsNotAValidHex2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match("G8");
            Assert.False(actual.Success());
            Assert.Equal("G8", actual.RemainingText());
        }

        [Fact]
        public void IsNotNullHex()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match(null);
            Assert.False(actual.Success());
            Assert.Null(actual.RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyHexString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var hex = new Choice(
                        digit,
                        new Choice(
                            new Range('a', 'f'),
                            new Range('A', 'F')
                        )
                    );

            var actual = hex.Match(string.Empty);
            Assert.False(actual.Success());
            Assert.Equal(string.Empty, actual.RemainingText());
        }

        [Fact]
        public void IsAValidIntValue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var intValue = new Choice(
                        new Choice(
                            new Character('-')
                        ),
                        digit
                    );

            var actual = intValue.Match("12");
            Assert.True(actual.Success());
            Assert.Equal("2", actual.RemainingText());
        }

        [Fact]
        public void IsAValidNegativeIntValue()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            var intValue = new Choice(
                        new Choice(
                            new Character('-')
                        ),
                        digit
                    );

            var actual = intValue.Match("-12");
            Assert.True(actual.Success());
            Assert.Equal("12", actual.RemainingText());
        }
    }
}
