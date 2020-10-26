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

            Assert.True(hex.Match("012"));
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

            Assert.True(hex.Match("12"));
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

            Assert.True(hex.Match("92"));
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

            Assert.True(hex.Match("a9"));
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

            Assert.True(hex.Match("f8"));
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

            Assert.True(hex.Match("A9"));
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

            Assert.True(hex.Match("F8"));
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

            Assert.False(hex.Match("g8"));
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

            Assert.False(hex.Match("G8"));
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

            Assert.False(hex.Match(null));
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

            Assert.False(hex.Match(string.Empty));
        }
    }
}
