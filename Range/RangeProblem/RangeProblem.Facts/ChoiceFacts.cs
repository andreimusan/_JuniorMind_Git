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

            Assert.Equal(digit.Match(null).RemainingText(), new FailedMatch(null).RemainingText());
        }

        [Fact]
        public void IsNotAnEmptyString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );

            Assert.Equal(digit.Match(string.Empty).RemainingText(), new FailedMatch(string.Empty).RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit1()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            var text = "012";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit2()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            var text = "12";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
        }

        [Fact]
        public void IsAValidStringDigit3()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            var text = "92";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
        }

        [Fact]
        public void IsNotAValidString()
        {
            var digit = new Choice(
                new Character('0'),
                new Range('1', '9')
            );
            var text = "a9";

            Assert.Equal(digit.Match(text).RemainingText(), new FailedMatch(text).RemainingText());
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

            var text = "012";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "12";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "92";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "a9";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "f8";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "A9";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "F8";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "g8";

            Assert.Equal(digit.Match(text).RemainingText(), new FailedMatch(text).RemainingText());
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

            var text = "G8";

            Assert.Equal(digit.Match(text).RemainingText(), new FailedMatch(text).RemainingText());
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

            Assert.Equal(digit.Match(null).RemainingText(), new FailedMatch(null).RemainingText());
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

            Assert.Equal(digit.Match(string.Empty).RemainingText(), new FailedMatch(string.Empty).RemainingText());
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

            var text = "12";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
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

            var text = "-12";

            Assert.Equal(digit.Match(text).RemainingText(), new SuccessMatch(text).RemainingText());
        }
    }
}
